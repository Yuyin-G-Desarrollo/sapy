Imports System.Xml

Public Class ContabilidadElectronicaBU
    Dim cuentasRFC As DataTable

    ''' <summary>
    ''' JUANA GUERRERO
    ''' 22-SEP-2015
    ''' BUSCA LAS POLIZAS DE LA EMPRESA X DEL MES Y AÑO INDICADOS
    ''' </summary>
    ''' <param name="periodo">MES DE CONSULTA</param>
    ''' <param name="anio">AÑO DE CONSULTA</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultarPolizasPeriodo(ByVal servidor As String, ByVal NombreBD As String, ByVal periodo As Integer, ByVal anio As Integer) As DataTable
        Dim objContabilidadDA As New Contabilidad.Datos.ContabilidadElectronicaDA
        Dim polizas As New DataTable
        Try
            polizas = objContabilidadDA.ConsultaPolizasPeriodo(periodo, anio, servidor, NombreBD)
        Catch ex As Exception
            Throw ex
        End Try
        Return polizas
    End Function

    ''' <summary>
    ''' JUANA GUERRERO
    ''' 22-SEP-2015
    ''' </summary>
    ''' <param name="servidor"></param>
    ''' <param name="NombreBD"></param>
    ''' <param name="polizaId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultarMovimientosPoliza(ByVal servidor As String, ByVal NombreBD As String, ByVal polizaId As Integer) As DataTable
        Dim objContabilidadDA As New Contabilidad.Datos.ContabilidadElectronicaDA
        Dim movimientos As New DataTable
        Try
            movimientos = objContabilidadDA.ConsultaMovimientosPoliza(polizaId.ToString, servidor, NombreBD)
        Catch ex As Exception
            Throw ex
        End Try
        Return movimientos
    End Function

    ''' <summary>
    ''' JUANA GUERRERO
    ''' 22-SEP-2015
    ''' </summary>
    ''' <param name="servidor"></param>
    ''' <param name="NombreBD"></param>
    ''' <param name="polizaId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultarComprobantesMovimiento(ByVal servidor As String, ByVal NombreBD As String, ByVal polizaId As Integer, ByVal referencia As String, ByVal tipoPoliza As Integer, ByVal moneda As String, ByVal numMovto As String) As DataTable
        Dim objContabilidadDA As New Contabilidad.Datos.ContabilidadElectronicaDA
        Dim comprobantes As New DataTable
        Try
            comprobantes = objContabilidadDA.ConsultaComprobantesMovimiento(polizaId.ToString, referencia, tipoPoliza.ToString, moneda, servidor, NombreBD, numMovto)
        Catch ex As Exception
            Throw ex
        End Try
        Return comprobantes
    End Function

    ''' <summary>
    ''' JUANA GUERRERO
    ''' 02-DIC-2015
    ''' </summary>
    ''' <param name="servidor"></param>
    ''' <param name="NombreBD"></param>
    ''' <param name="polizaId"></param>
    ''' <param name="tipoPoliza"></param>
    ''' <param name="moneda"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultarCfdsTransferencia(ByVal servidor As String, ByVal NombreBD As String, ByVal polizaId As Integer, ByVal tipoPoliza As Integer, ByVal moneda As String) As DataTable
        Dim objContabilidadDA As New Contabilidad.Datos.ContabilidadElectronicaDA
        Dim comprobantes As New DataTable
        Try
            comprobantes = objContabilidadDA.ConsultaCfdsTransferencia(polizaId.ToString, tipoPoliza.ToString, moneda, servidor, NombreBD)
        Catch ex As Exception
            Throw ex
        End Try
        Return comprobantes
    End Function

    ''' <summary>
    ''' JUANA GUERRERO
    ''' 28-OCT-2015
    ''' </summary>
    ''' <param name="NombreBD"></param>
    ''' <param name="polizaId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultarTransferencias(ByVal NombreBD As String, ByVal polizaId As Integer) As DataTable
        Dim objContabilidadDA As New Contabilidad.Datos.ContabilidadElectronicaDA
        Dim cheques As New DataTable
        Try
            cheques = objContabilidadDA.ConsultaTransferencias(polizaId.ToString, NombreBD)
        Catch ex As Exception
            Throw ex
        End Try
        Return cheques
    End Function

    ''' <summary>
    ''' JUANA GUERRERO 
    ''' 28-10-2015
    ''' </summary>
    ''' <param name="NombreBD"></param>
    ''' <param name="polizaId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultarCheques(ByVal NombreBD As String, ByVal polizaId As Integer) As DataTable
        Dim objContabilidadDA As New Contabilidad.Datos.ContabilidadElectronicaDA
        Dim cheques As New DataTable
        Try
            cheques = objContabilidadDA.ConsultaCheques(polizaId.ToString, NombreBD)
        Catch ex As Exception
            Throw ex
        End Try
        Return cheques
    End Function


    Public Function ConstruyeXmlPolizasPeriodo(ByVal idEmpresaSay As Integer, ByVal mes As String, ByVal anio As String, ByVal rutaGuardar As String, ByVal RFCEmpresa As String, ByVal tipoSolicitud As String, ByVal noOrden As String) As String
        Dim result As String = String.Empty
        Dim objEmpresaDA As New Contabilidad.Datos.AltaPolizaDA
        Dim objContabilidadDA As New Contabilidad.Datos.ContabilidadElectronicaDA
        Dim empresa As New DataTable
        Dim polizas As New DataTable
        Dim servidor As String = String.Empty
        Dim nombreDB As String = String.Empty

        Dim myXmlTextWriter As XmlTextWriter = New XmlTextWriter(rutaGuardar, System.Text.Encoding.UTF8)
        myXmlTextWriter.Formatting = System.Xml.Formatting.Indented
        myXmlTextWriter.WriteStartDocument(False)

        'Crear el elemento de documento principal Comprobante.
        myXmlTextWriter.WriteStartElement("PLZ:Polizas")
        myXmlTextWriter.WriteAttributeString("xmlns:PLZ", "www.sat.gob.mx/esquemas/ContabilidadE/1_1/PolizasPeriodo")
        myXmlTextWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
        myXmlTextWriter.WriteAttributeString("xsi:schemaLocation", "www.sat.gob.mx/esquemas/ContabilidadE/1_1/PolizasPeriodo http://www.sat.gob.mx/esquemas/ContabilidadE/1_1/PolizasPeriodo/PolizasPeriodo_1_1.xsd")
        myXmlTextWriter.WriteAttributeString("Version", "1.1")
        myXmlTextWriter.WriteAttributeString("RFC", RFCEmpresa)
        myXmlTextWriter.WriteAttributeString("Mes", mes)
        myXmlTextWriter.WriteAttributeString("Anio", anio)
        myXmlTextWriter.WriteAttributeString("TipoSolicitud", tipoSolicitud)
        myXmlTextWriter.WriteAttributeString("NumOrden", noOrden)

        empresa = objEmpresaDA.datosServidorEmpresa(idEmpresaSay)
        cuentasRFC = objContabilidadDA.ConsultaCuentasRFC_Clientes(idEmpresaSay)

        If empresa.Rows.Count > 0 Then
            servidor = empresa.Rows(0).Item("essc_servidor")
            nombreDB = empresa.Rows(0).Item("essc_empresacontpaq")
            Try
                polizas = ConsultarPolizasPeriodo(servidor, nombreDB, mes, anio)

                'PolXml = New PolizasXML.PolizaXML("2015", "08", 12, "RFC123", "AF", "ABC6577777/88")
                'InicializaXMLPolizas(RFCEmpresa, mes, anio, tipoSolicitud, noOrden, rutaGuardar)

                If polizas.Rows.Count > 0 Then
                    Dim numIdenPol As String = String.Empty
                    Dim polizaID As String = String.Empty
                    Dim Fecha As String = String.Empty
                    Dim Concepto As String = String.Empty
                    Dim tipoPoliza As Integer = 0
                    Dim nombreTipoPoliza As String = String.Empty
                    Dim folio As String = String.Empty
                    Dim contador As Integer = 1

                    For Each poliza As DataRow In polizas.Rows


                        'DATOS PARA NODO DE PÓLIZA

                        Fecha = poliza.Item("Fecha")
                        polizaID = poliza.Item("NumUnIdenPol")
                        Concepto = poliza.Item("Concepto")
                        tipoPoliza = poliza.Item("TipoPol")
                        folio = poliza.Item("Folio")
                        nombreTipoPoliza = poliza.Item("TipoPoliza")
                        numIdenPol = anio + mes + folio + nombreTipoPoliza

                        ''AQUIIII
                        'PolXml.AgregaDatosPoliza(tipoPoliza.ToString, numIdenPol.ToString, Fecha.ToString, Concepto.ToString)
                        myXmlTextWriter.WriteStartElement("PLZ:Poliza")
                        myXmlTextWriter.WriteAttributeString("NumUnIdenPol", numIdenPol)
                        myXmlTextWriter.WriteAttributeString("Fecha", Fecha)
                        myXmlTextWriter.WriteAttributeString("Concepto", Concepto.Trim)

                        'Console.WriteLine(contador.ToString + " de " + polizas.Rows.Count.ToString + " > " + numIdenPol.ToString)
                        contador = contador + 1

                        Dim movimientos As New DataTable
                        movimientos = ConsultarMovimientosPoliza(servidor, nombreDB, polizaID)

                        If movimientos.Rows.Count > 0 Then
                            Dim numMovimiento As Integer = 0
                            Dim numCta As String = String.Empty
                            Dim desCta As String = String.Empty
                            Dim conceptoMovimiento As String = String.Empty
                            Dim debe As Double = 0
                            Dim haber As Double = 0
                            Dim moneda As String = String.Empty
                            Dim referencia As String = String.Empty
                            For Each movimiento As DataRow In movimientos.Rows

                                'DATOS PARA NODO DEL MOVIMIENTO (TRANSACCIÓN)
                                numMovimiento = movimiento.Item("NumMovto")
                                numCta = movimiento.Item("NumCta")
                                desCta = movimiento.Item("DesCta")
                                conceptoMovimiento = movimiento.Item("Concepto")
                                If conceptoMovimiento.Trim.Replace(" ", "") = "" Then
                                    conceptoMovimiento = Concepto
                                End If
                                debe = movimiento.Item("Debe")
                                haber = movimiento.Item("Haber")
                                moneda = movimiento.Item("Moneda")
                                If Not IsDBNull(movimiento.Item("Referencia")) Then
                                    referencia = movimiento.Item("Referencia")
                                End If

                                ''AQUI MOVIMIENTO
                                myXmlTextWriter.WriteStartElement("PLZ:Transaccion")
                                myXmlTextWriter.WriteAttributeString("NumCta", numCta)
                                myXmlTextWriter.WriteAttributeString("DesCta", desCta)
                                myXmlTextWriter.WriteAttributeString("Concepto", conceptoMovimiento)
                                myXmlTextWriter.WriteAttributeString("Debe", Math.Round(debe, 2))
                                myXmlTextWriter.WriteAttributeString("Haber", Math.Round(haber, 2))
                                'PolXml.AgregaDatosTransaccion(numCta, Concepto, conceptoMovimiento, debe, haber, moneda, 1, tipoPoliza, numIdenPol, desCta)

                                Dim comprobantes As New DataTable
                                If numCta.Substring(0, 3) = "105" Or numCta.Substring(0, 3) = "205" Or numCta.Substring(0, 3) = "201" Then
                                    comprobantes = ConsultarComprobantesMovimiento(servidor, nombreDB, polizaID, referencia, tipoPoliza, moneda, numMovimiento.ToString)
                                End If

                                If comprobantes.Rows.Count > 0 Then
                                    Dim uuid As String = String.Empty
                                    Dim rfc As String = String.Empty
                                    Dim importe As Double = 0
                                    For Each comprobante As DataRow In comprobantes.Rows
                                        If numCta.Substring(0, 3) = "105" Then
                                            rfc = buscaRFC(numCta)
                                        Else
                                            If IsDBNull(comprobante.Item("RFC")) Then
                                                rfc = ""
                                            Else
                                                rfc = comprobante.Item("RFC").ToString
                                            End If
                                        End If
                                        If Not rfc = "" Then
                                            ''DATOS PARA EL NODO DEL COMPROBANTE
                                            uuid = comprobante.Item("UUID_CFDI")
                                            importe = comprobante.Item("MontoTotal")
                                            ' Console.WriteLine("                 " + rfc + "  " + uuid)
                                            'MONEDA 

                                            'PolXml.AgregaDatosComprobantes(uuid, importe, rfc, tipoPoliza, numIdenPol, numCta, conceptoMovimiento)
                                            'AQUIIII
                                            myXmlTextWriter.WriteStartElement("PLZ:CompNal")
                                            myXmlTextWriter.WriteAttributeString("UUID_CFDI", uuid)
                                            myXmlTextWriter.WriteAttributeString("RFC", rfc)
                                            myXmlTextWriter.WriteAttributeString("MontoTotal", Math.Round(importe, 2))
                                            myXmlTextWriter.WriteAttributeString("Moneda", moneda)
                                            myXmlTextWriter.WriteEndElement() 'cierra compnal
                                        End If
                                    Next
                                End If

                                comprobantes = New DataTable
                                If nombreTipoPoliza.Contains("T-") And (numCta.Substring(0, 3) = "118" Or numCta.Substring(0, 3) = "119" Or numCta.Substring(0, 3) = "102") Then
                                    comprobantes = ConsultarCfdsTransferencia(servidor, nombreDB, polizaID, tipoPoliza, moneda)
                                End If


                                ''INSERTA TODOS LOS cfds DE LA PÓLIZA AL MOVIMIENTO DE LA TRANSFERENCIA
                                If comprobantes.Rows.Count > 0 Then
                                    Dim uuid As String = String.Empty
                                    Dim rfc As String = String.Empty
                                    Dim importe As Double = 0
                                    For Each comprobante As DataRow In comprobantes.Rows
                                        If IsDBNull(comprobante.Item("RFC")) Then
                                            rfc = ""
                                        Else
                                            rfc = comprobante.Item("RFC").ToString
                                        End If

                                        If Not rfc = "" Then
                                            ''DATOS PARA EL NODO DEL COMPROBANTE
                                            uuid = comprobante.Item("UUID_CFDI")
                                            importe = comprobante.Item("MontoTotal")
                                            ' Console.WriteLine("                 " + rfc + "  " + uuid)
                                            'MONEDA 

                                            'PolXml.AgregaDatosComprobantes(uuid, importe, rfc, tipoPoliza, numIdenPol, numCta, conceptoMovimiento)
                                            'AQUIIII
                                            myXmlTextWriter.WriteStartElement("PLZ:CompNal")
                                            myXmlTextWriter.WriteAttributeString("UUID_CFDI", uuid)
                                            myXmlTextWriter.WriteAttributeString("RFC", rfc)
                                            myXmlTextWriter.WriteAttributeString("MontoTotal", Math.Round(importe, 2))
                                            myXmlTextWriter.WriteAttributeString("Moneda", moneda)
                                            myXmlTextWriter.WriteEndElement() 'cierra compnal
                                        End If
                                    Next
                                End If
                                ''FIN INSERTA TODOS LOS cfds DE LA PÓLIZA AL MOVIMIENTO DE LA TRANSFERENCIA


                                'Inicia (YazminR)(29/10/2015)(Agregar cheques y transferencias)
                                ' If numCta.Substring(0, 3) = "102" Then
                                Dim cheques As New DataTable
                                cheques = ConsultarCheques(nombreDB, polizaID)

                                If cheques.Rows.Count > 0 Then
                                    Dim numCheque As Integer = 0
                                    Dim BancoEmisorNac As String = String.Empty
                                    Dim CtaOrigen As String = String.Empty
                                    Dim fechaCheque As String = String.Empty
                                    Dim beneficiario As String = String.Empty
                                    Dim rfc As String = String.Empty
                                    Dim monto As Double = 0
                                    Dim tipoCambio As String = String.Empty

                                    For Each cheque As DataRow In cheques.Rows

                                        'DATOS PARA NODO DE LOS CHEQUES
                                        numCheque = cheque.Item("No Cheque")
                                        BancoEmisorNac = cheque.Item("Banco Emisor")
                                        CtaOrigen = cheque.Item("Cta Origen")
                                        fechaCheque = cheque.Item("Fecha Cheque")
                                        beneficiario = cheque.Item("Beneficiario")
                                        rfc = cheque.Item("RFC Tercero vinc")
                                        monto = cheque.Item("Monto")
                                        moneda = cheque.Item("Moneda")
                                        tipoCambio = cheque.Item("Tipo Cambio")

                                        ''Genera xml
                                        myXmlTextWriter.WriteStartElement("PLZ:Cheque")
                                        myXmlTextWriter.WriteAttributeString("Num", numCheque)
                                        myXmlTextWriter.WriteAttributeString("BanEmisNal", BancoEmisorNac)
                                        myXmlTextWriter.WriteAttributeString("CtaOri", CtaOrigen)
                                        myXmlTextWriter.WriteAttributeString("Fecha", fechaCheque)
                                        myXmlTextWriter.WriteAttributeString("Benef", beneficiario)
                                        myXmlTextWriter.WriteAttributeString("RFC", rfc)
                                        myXmlTextWriter.WriteAttributeString("Monto", Math.Round(monto, 2))
                                        myXmlTextWriter.WriteAttributeString("TipCamb", tipoCambio)
                                        myXmlTextWriter.WriteAttributeString("Moneda", moneda)
                                        myXmlTextWriter.WriteEndElement()
                                    Next
                                End If


                                Dim transferencias As New DataTable
                                transferencias = ConsultarTransferencias(nombreDB, polizaID)

                                If transferencias.Rows.Count > 0 Then
                                    Dim CtaOrigen As String = String.Empty
                                    Dim BancoOrigenNac As String = String.Empty
                                    Dim CtaDestino As String = String.Empty
                                    Dim BancoDestinoNac As String = String.Empty
                                    Dim fechaTrans As String = String.Empty
                                    Dim beneficiario As String = String.Empty
                                    Dim rfc As String = String.Empty
                                    Dim monto As Double = 0
                                    Dim tipoCambio As String = String.Empty

                                    For Each transferencia As DataRow In transferencias.Rows
                                        'DATOS PARA NODO DE TRANSFERENCIAS
                                        CtaOrigen = transferencia.Item("Cta Origen")
                                        BancoOrigenNac = transferencia.Item("Banco Origen")
                                        CtaDestino = transferencia.Item("Cta Destino")
                                        BancoDestinoNac = transferencia.Item("Banco Destino")
                                        fechaTrans = transferencia.Item("Fecha Transferencia")
                                        beneficiario = transferencia.Item("Beneficiario")
                                        rfc = transferencia.Item("RFC Tercero vinc")
                                        monto = transferencia.Item("Monto")
                                        moneda = transferencia.Item("Moneda")
                                        tipoCambio = transferencia.Item("Tipo cambio")

                                        If BancoDestinoNac <> "" And rfc <> "" Then
                                            ''Genera xml
                                            myXmlTextWriter.WriteStartElement("PLZ:Transferencia")
                                            myXmlTextWriter.WriteAttributeString("CtaOri", CtaOrigen)
                                            myXmlTextWriter.WriteAttributeString("BancoOriNal", BancoOrigenNac)
                                            myXmlTextWriter.WriteAttributeString("CtaDest", CtaDestino)
                                            myXmlTextWriter.WriteAttributeString("BancoDestNal", BancoDestinoNac)
                                            myXmlTextWriter.WriteAttributeString("Fecha", fechaTrans)
                                            myXmlTextWriter.WriteAttributeString("Benef", beneficiario)
                                            myXmlTextWriter.WriteAttributeString("RFC", rfc)
                                            myXmlTextWriter.WriteAttributeString("Monto", Math.Round(monto, 2))
                                            myXmlTextWriter.WriteAttributeString("TipCamb", tipoCambio)
                                            myXmlTextWriter.WriteAttributeString("Moneda", moneda)
                                            myXmlTextWriter.WriteEndElement()
                                        End If
                                    Next
                                End If
                                'End If
                                'FIN CHEQUES Y TRANSFERENCIAS
                                myXmlTextWriter.WriteEndElement() 'cierra Transaccion
                            Next

                        End If
                        myXmlTextWriter.WriteEndElement() 'cierra Poliza
                    Next
                End If

                'PolXml.GeneraArchivos()



                myXmlTextWriter.WriteEndElement() 'cierra POLIZAS

                myXmlTextWriter.Flush()
                myXmlTextWriter.Close()

            Catch ex As Exception
                'Console.WriteLine(ex.Message.ToString)
                result = "No fué posible generar el reporte de pólizas. [" + ex.Message.ToString + "]"
            End Try
        Else
            'NO EXISTE EMPRESA
            result = "La empresa seleccionada no está configurada. [IdEmpresa= " + idEmpresaSay + "]"
        End If

        Return result
    End Function


    Public Function buscaRFC(ByRef cuentaContable As String) As String
        buscaRFC = ""
        Dim drarray() As DataRow
        Dim filterExp As String = "cuenta = '" + cuentaContable + "'"
        Dim sortExp As String = "cuenta"
        Dim i As Integer
        drarray = cuentasRFC.Select(filterExp, sortExp, DataViewRowState.CurrentRows)
        For i = 0 To (drarray.Length - 1)
            buscaRFC = drarray(i)("rfc").ToString
        Next

        buscaRFC = buscaRFC.Replace(" ", "").Replace("-", "")
    End Function


End Class
