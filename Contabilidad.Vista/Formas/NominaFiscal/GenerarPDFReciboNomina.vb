Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export

Public Class GenerarPDFReciboNomina

    Public Sub generaPDF(ByVal entidadRecibo As Entidades.ReciboNomina, ByVal Percepciones As DataTable,
                         ByVal OtrasPercepciones As DataTable, ByVal Deducciones As DataTable,
                         ByVal Incapacidades As DataTable,
                         ByVal rutaPDF As String,
                         ByVal tipo As String,
                         ByVal opcion As String)
        'Dim pdfSettings = New StiPdfExportSettings()
        ''Dim entidadRecibo As New Entidades.ReciboNomina

        '' ''D A T O S   D E L   P A T R O N   -   E M P R E S A
        ''entidadRecibo.PNombrePatron = "JUAN RAUL VILLAGRANA ONTIVEROS"
        ''entidadRecibo.PRfcEmpresa = "VIOJ7508036GA"
        ''entidadRecibo.PRegistroPatronal = "B4890464109"
        ''entidadRecibo.PRegimenFiscal = "PERSONAS FISICAS ACTIVIDAD EMPRESARIAL Y PROFESIONAL"

        ' '' D A T O S   D E L   C O M P R O B A N T E
        '' ''FECHA ENCABEZADO FORMATO STRING DD/Mes/AAAA
        ''entidadRecibo.PFecha = "28/May/2016"

        '' ''HORA ENCABEZADO FORMATO STRING HH:MM:SS
        ''entidadRecibo.PHora = "09:16:06"

        '' '' FECHA Y HORA DE TIMBRADO FORMATO STRING 2016-05-28T09:17:13
        ''entidadRecibo.PFechaHoraCertificacion = "2016-05-28T09:17:13"

        '' '' FOLIO FISCAL
        ''entidadRecibo.PUUID = "3B8FC7B5-10A0-4EFB-AD9A-335BCE08DB88"

        '' ''SERIE DEL CERTIFICADO DEL EMISOR
        ''entidadRecibo.PSerieCertificadoEmisor = "00001000000201582574"

        '' ''NO. DE SERIE DEL CERTIFICADO DEL SAT
        ''entidadRecibo.PSerieCertificadoSAT = "00001000000202864883"

        '' ''SELLO DIGITAL DEL CFDI
        ''entidadRecibo.PSelloDigital = "bTkPgfC36Qh6ZwN/9B8HBTx/eC+0AuAOg5/JEdYfugujo0i0rRpjl7gvkPxagGEehYfPcF52r1yIzYFTGnq2EDLC3X8WUSeQPQCT25U5ed0wptFrbAwLDZBoY+oMMM8IdipfsyhO632L9SYA1RIKU9TCMwxRi7lpvNG8ujdEbt8="

        '' ''SELLO DEL SAT
        ''entidadRecibo.PSelloSAT = "pAcbqXdc0zGrDEhux0I0A05WowxFbCQBpxCUBQY8Kw/j3wWYNm2dw1GcLKoqxgmjx4HTs4PJRW0zOrPDS1VNMNJsJP/hfSe9G449TTus5/1Cac5dqKpihc1K+onEJKLA8WrGsNoKbw2oufjcIae/WW3ou5UlWK/7CYfqJ8hgDdc="

        '' ''CADENA ORIGINAL
        ''entidadRecibo.PCadenaOriginal = "||1.0|3B8FC7B5-10A0-4EFB-AD9A-335BCE08DB88|2016-05-28T09:17:13|bTkPgfC36Qh6ZwN/9B8HBTx/eC+0AuAOg5/JEdYfugujo0i0rRpjl7gvkPxagGEehYfPcF52r1yIzYFTGnq2EDLC3X8WUSeQPQCT25U5ed0wptFrbAwLDZBoY+oMMM8IdipfsyhO632L9SYA1RIKU9TCMwxRi7lpvNG8ujdEbt8=|00001000000202864883||"

        '' ''CONTENIDO DEL CÓDIGO QR
        ''entidadRecibo.PQR = "||1.0|3B8FC7B5-10A0-4EFB-AD9A-335BCE08DB88|2016-05-28T09:17:13|"

        '' ''METODO DE PAGO
        ''entidadRecibo.PMetodoPago = "EFECTIVO"

        '' ''FORMA DE PAGO
        ''entidadRecibo.PFormaPago = "PAGO EN UNA SOLA EXHIBICIÓN"


        '' ''D A T O S   D E L   C O L A B O R A D O R

        ' ''CLAVE DEL COLABORADOR ASIGNADA POR CONTABILIDAD
        ''entidadRecibo.PClaveColaborador = "G001"

        ' ''NOMBRE DEL COLABORADOR (PATERNO, MATERNO, NOMBRES)
        ''entidadRecibo.PNombreColaborador = "GUERRERO GOMEZ JUANA"

        '' ''RFC COLABORADOR
        ''entidadRecibo.PRFCColaborador = "VAIV820413RC7"

        '' ''CURP COLABORADOR
        ''entidadRecibo.PCURPColaborador = "VAIV820413MGTLBR06"

        '' ''FECHA DE INGRESO DEL COLABORADOR EN FORMATO STRING DD/Mes/AAAA (04/Jul/2005)
        ''entidadRecibo.PFechaInicioRelacion = "04/Jul/2005"

        '' ''TIPO DE JORNADA
        ''entidadRecibo.PJornada = "DIURNO"

        '' ''NUMERO DE SEGURO SOCIAL
        ''entidadRecibo.PNSS = "12998231364"

        '' ''TIPO DE SALARIO
        ''entidadRecibo.PTipoSalario = "FIJO"

        '' ''PUESTO
        ''entidadRecibo.PPuesto = "PRELIMINAR"

        ' ''DEPARTAMENTO'
        ''entidadRecibo.PDepartamento = "PESPUNTE"


        '' '' D A T O S   D E   L A   N O M I N A

        ' ''NUMERO DE SEMANA
        ''entidadRecibo.PNumeroSemana = "21"

        '' ''TIPO DE PERIODO
        ''entidadRecibo.PTipoPeriodo = "SEMANAL"

        '' ''RANGO DE FECHAS DEL PERIODO DE NOMINA EN FORMATO STRING CONCATENANDO INICIO Y FIN SEPARADOS POR GUIÓN
        ''entidadRecibo.PRangoPeriodo = "18/May/2016 - 24/May/2016"

        '' ''FECHA DE PAGO EN FORMATO STRING
        ''entidadRecibo.PFechaPago = "26/May/2016"

        '' ''NUMERO DE DIAS PAGADOS AL COLABORADOR
        ''entidadRecibo.PDiasPago = 5.83

        '' ''SALARIO DIARIO INTEGRADO
        ''entidadRecibo.PSDI = 126

        '' ''SUMA DE PERCEPCIONE: GRAVADO
        ''entidadRecibo.PSumaPercepcionesGravado = 768.53

        '' ''SUMA DE PERCEPCIONE: EXENTO
        ''entidadRecibo.PSumaPercepcionesExento = 33.93

        '' ''SUMA DE PERCEPCIONE: TOTAL
        ''entidadRecibo.PSumaPercepcionesTotal = 802.49

        '' ''SUBTOTAL
        ''entidadRecibo.PSubtotal = 802.49

        '' ''TOTAL DESCUENTOS
        ''entidadRecibo.PDescuentos = 17.49

        '' ''TOTAL RETENCIONES
        ''entidadRecibo.PRetenciones = 0.0

        ' ''TOTAL
        ''entidadRecibo.PTotal = 785.0

        '' ''NETO DEL RECIBO
        ''entidadRecibo.PNetoRecibo = 785.0

        ' ''IMPORTE CON LETRA
        ''entidadRecibo.PImporteLetra = "SETESCIENTOS OCHETA Y CINCO PESOS 00/100 M.N."

        '' '' G R I D   D E   P E R C E P C I O N E S
        ''Dim Percepciones = New DataTable("DSPercepciones")
        ''With Percepciones
        ''    .Columns.Add("AgrupadorSAT")
        ''    .Columns.Add("No")
        ''    .Columns.Add("Concepto")
        ''    .Columns.Add("Gravado")
        ''    .Columns.Add("Exento")
        ''    .Columns.Add("Total")
        ''End With

        ''Percepciones.Rows.Add("001", "001", "SUELDO", 598.85, 0, 598.85)
        ''Percepciones.Rows.Add("001", "003", "SEPTIMO DÍA", 99.81, 0, 99.81)
        ''Percepciones.Rows.Add("016", "014", "PREMIO DE ASISTENCIA", 0, 0, 0)
        ''Percepciones.Rows.Add("010", "015", "PREMIO DE PUNTUALIDAD", 69.87, 0, 69.87)

        'entidadRecibo.PPercepciones = Percepciones

        '' '' G R I D   D E   O T R A S   P E R C E P C I O N E S

        ''Dim OtrasPercepciones = New DataTable("DSOtrasPercepciones")
        ''With OtrasPercepciones
        ''    .Columns.Add("AgrupadorSAT")
        ''    .Columns.Add("No")
        ''    .Columns.Add("Concepto")
        ''    .Columns.Add("Gravado")
        ''    .Columns.Add("Exento")
        ''    .Columns.Add("Total")
        ''End With

        ''OtrasPercepciones.Rows.Add("017", "039", "SUBCIDIO AL EMPLEO (SP)", 598.85, 0, 598.85)
        'entidadRecibo.POtrasPercepciones = OtrasPercepciones

        '' '' G R I D   D E   D E D U C C I O N E S

        ''Dim Deducciones = New DataTable("DSDeducciones")
        ''With Deducciones
        ''    .Columns.Add("AgrupadorSAT")
        ''    .Columns.Add("No")
        ''    .Columns.Add("Concepto")
        ''    .Columns.Add("Total")
        ''End With

        ''Deducciones.Rows.Add("002", "049", "I.S.R. (SP)", 0)
        ''Deducciones.Rows.Add("001", "052", "I.M.S.S.", 17.46)
        ''Deducciones.Rows.Add("004", "099", "AJUSTE AL NETO", 0.03)

        'entidadRecibo.PDeducciones = Deducciones

        ' '' G R I D   D E   I N C A P A C I D A D E S

        ''Dim Incapacidades = New DataTable("DSIncapacidades")
        ''With Incapacidades
        ''    .Columns.Add("dias")
        ''    .Columns.Add("Tipo")
        ''    .Columns.Add("Descuento")
        ''End With

        ''Incapacidades.Rows.Add(1, "ENFERMEDAD GENERAL", 119.77)

        'entidadRecibo.PIncapacidades = Incapacidades

        '' I N I C I A   I M P R E S I Ó N   D E   R E P O R T E 
        'Dim EntidadReporte As New Entidades.Reportes
        'Dim objBuReportes As New Framework.Negocios.ReportesBU
        'Dim strReporte As String = String.Empty

        'If tipo = "FINIQUITO" Then
        '    If opcion = "CANCELACION" Then
        '        strReporte = "RECIBO_CANC_NOMINA_FISCAL_FINIQUITO"
        '    Else
        '        strReporte = "RECIBO_NOMINA_FISCAL_FINIQUITO"
        '    End If
        'Else
        '    If opcion = "CANCELACION" Then
        '        strReporte = "RECIBO_CANC_NOMINA_FISCAL"
        '    Else
        '        strReporte = "RECIBO_NOMINA_FISCAL"
        '    End If
        'End If

        'EntidadReporte = objBuReportes.LeerReporteporClave(strReporte)
        'Dim archivoReporte As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
        'My.Computer.FileSystem.WriteAllText(archivoReporte, EntidadReporte.Pxml, False)
        'Dim reporte As New StiReport
        'reporte.Load(archivoReporte)
        'reporte.Compile()
        'reporte("NombrePatron") = entidadRecibo.PNombrePatron
        'reporte("RfcEmpresa") = entidadRecibo.PRfcEmpresa
        'reporte("RegimenFiscal") = entidadRecibo.PRegimenFiscal
        'reporte("RegistroPatronal") = entidadRecibo.PRegistroPatronal
        'reporte("Fecha") = entidadRecibo.PFecha
        'reporte("Hora") = entidadRecibo.PHora
        'reporte("FechaHoraCertificacion") = entidadRecibo.PFechaHoraCertificacion

        'If opcion = "CANCELACION" Then
        '    reporte("FechaHoraCancelacion") = entidadRecibo.PFechaHoraCancelacion
        'End If

        'reporte("UUID") = entidadRecibo.PUUID
        'reporte("SerieCertificadoEmisor") = entidadRecibo.PSerieCertificadoEmisor
        'reporte("SerieCertificadoSAT") = entidadRecibo.PSerieCertificadoSAT
        'reporte("SelloDigital") = entidadRecibo.PSelloDigital
        'reporte("SelloSAT") = entidadRecibo.PSelloSAT
        'reporte("CadenaOriginalComp") = entidadRecibo.PCadenaOriginal
        'reporte("QR") = entidadRecibo.PQR
        'reporte("MetodoPago") = entidadRecibo.PMetodoPago
        'reporte("FormaPago") = entidadRecibo.PFormaPago
        'reporte("ClaveColaborador") = entidadRecibo.PClaveColaborador
        'reporte("NombreColaborador") = entidadRecibo.PNombreColaborador
        'reporte("RFCColaborador") = entidadRecibo.PRFCColaborador
        'reporte("CURPColaborador") = entidadRecibo.PCURPColaborador
        'reporte("FechaInicioRelacion") = entidadRecibo.PFechaInicioRelacion
        'reporte("Jornada") = entidadRecibo.PJornada
        'reporte("NSS") = entidadRecibo.PNSS
        'reporte("FechaPago") = entidadRecibo.PFechaPago
        'reporte("TipoSalario") = entidadRecibo.PTipoSalario
        'reporte("Puesto") = entidadRecibo.PPuesto
        'reporte("Departamento") = entidadRecibo.PDepartamento
        'reporte("NumeroSemana") = entidadRecibo.PNumeroSemana
        'reporte("TipoPeriodo") = entidadRecibo.PTipoPeriodo
        'reporte("RangoPeriodo") = entidadRecibo.PRangoPeriodo
        'reporte("DiasPago") = entidadRecibo.PDiasPago
        'reporte("SDI") = entidadRecibo.PSDI
        'reporte("SumaPercepcionesGravado") = entidadRecibo.PSumaPercepcionesGravado
        'reporte("SumaPercepcionesExento") = entidadRecibo.PSumaPercepcionesExento
        'reporte("SumaPercepcionesTotal") = entidadRecibo.PSumaPercepcionesTotal
        'reporte("SumaOtrasPercepcionesGravado") = entidadRecibo.PSumaOtrasPercepcionesGravado
        'reporte("SumaOtrasPercepcionesExento") = entidadRecibo.PSumaOtrasPercepcionesExento
        'reporte("SumaOtrasPercepcionesTotal") = entidadRecibo.PSumaOtrasPercepcionesTotal
        'reporte("Subtotal") = entidadRecibo.PSubtotal
        'reporte("Descuentos") = entidadRecibo.PDescuentos
        'reporte("Retenciones") = entidadRecibo.PRetenciones
        'reporte("Total") = entidadRecibo.PTotal
        'reporte("NetoRecibo") = entidadRecibo.PNetoRecibo
        'reporte("ImporteLetra") = entidadRecibo.PImporteLetra
        'reporte("TotalGravado") = entidadRecibo.PSumaPercepcionesGravado + entidadRecibo.PSumaOtrasPercepcionesGravado
        'reporte("TotalExento") = entidadRecibo.PSumaPercepcionesExento + entidadRecibo.PSumaOtrasPercepcionesExento
        'reporte("TotalSuma") = entidadRecibo.PSumaPercepcionesTotal + entidadRecibo.PSumaOtrasPercepcionesTotal

        'Dim ds As New DataSet
        'ds.DataSetName = "DSRecibo"
        'ds.Tables.Add(entidadRecibo.PPercepciones)
        'ds.Tables.Add(entidadRecibo.POtrasPercepciones)
        'ds.Tables.Add(entidadRecibo.PDeducciones)
        'ds.Tables.Add(entidadRecibo.PIncapacidades)
        ''reporte.Dictionary.Clear()
        'reporte.RegData(ds)


        ''reporte.Dictionary.Synchronize()
        ''reporte.Show()
        'reporte.Render()
        'reporte.ExportDocument(StiExportFormat.Pdf, rutaPDF, pdfSettings)
        'reporte.Dispose()
    End Sub

End Class
