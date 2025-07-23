' Rodrigo Martínez  22-SEP-2015
' Genera la estructura XML del Archivo Electronico para Acumulado de Polizas
Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Xsl
Imports System.IO
Imports System.IO.Directory
Imports System.Text
Imports System.Diagnostics

Namespace PolizasXML

    Public Class PolizaXML
        Dim URI_SAT As String = "www.sat.gob.mx/esquemas/ContabilidadE/1_1/PolizasPeriodo"
        Public Archivo_XSLT As String
        Public Archivo_XML As String
        Public Directorio_Guardado As String

        ' Esta variable de nivel de modulo nos facilita las operaciones en las demas subrutinas
        Private m_xmlDOM As System.Xml.XmlDocument
        Private Nodo As System.Xml.XmlNode
        Private Const DIR_SAT = "\"
        Private Const DIR_PKI = "\"
        Private Carpeta_xml As String
        Private Rutafactura As String
        Private vAño As Integer
        Private vMes As Integer
        Private vTotalCtas As Integer
        Private vRFC As String
        Private vTipoSolicitud As String
        Private vNumOrden As String

        Sub New(ByVal pAño As String, ByVal pMes As Integer, ByVal pTotalCtas As Integer, ByVal pRFC As String, ByVal pTipoSolicitud As String, pNumOrden As String)
            MyBase.New()
            vAño = pAño
            vMes = pMes
            vTotalCtas = pTotalCtas
            vRFC = pRFC
            vTipoSolicitud = pTipoSolicitud
            vNumOrden = pNumOrden
            CreaPolizas()
        End Sub

        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Private Sub CreaPolizas()
            Dim nPolizas As System.Xml.XmlNode
            Dim ElementNodo As System.Xml.XmlElement
            Dim oDOM As XmlDocument = New XmlDocument()
            Nodo = oDOM.CreateProcessingInstruction("xml", "version=""1.0"" encoding=""UTF-8"" standalone=""yes""?")
            oDOM.AppendChild(Nodo)

            m_xmlDOM = oDOM
            m_xmlDOM.Normalize()
            nPolizas = m_xmlDOM.CreateElement("Polizas", "http://www.sat.gob.mx/polizas")
            ElementNodo = nPolizas
            ElementNodo.SetAttribute("xmlns:PLZ", URI_SAT)
            ElementNodo.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
            ElementNodo.SetAttribute("xsi:schemaLocation", "www.sat.gob.mx/esquemas/ContabilidadE/1_1/PolizasPeriodo http://www.sat.gob.mx/esquemas/ContabilidadE/1_1/PolizasPeriodo/PolizasPeriodo_1_1.xsd")
            ElementNodo.SetAttribute("version", "1.1")
            ElementNodo.SetAttribute("RFC", vRFC)
            ElementNodo.SetAttribute("Mes", vMes)
            ElementNodo.SetAttribute("Anio", vAño)
            ElementNodo.SetAttribute("TipoSolicitud", vTipoSolicitud)
            ElementNodo.SetAttribute("NumOrden", vNumOrden)

            'Añexa el registro hijo al Objeto Poliza
            m_xmlDOM.AppendChild(nPolizas)
            Nodo = nPolizas
            InsentarNodo(nPolizas)
            nPolizas.Prefix = "PLZ"

        End Sub

        Public Sub AgregaDatosPoliza(ByVal pTipo As String, ByVal pNum As String, ByVal pFecha As Date, ByVal pConcepto As String)
            Dim ePolizas As System.Xml.XmlElement
            Dim ePoliza As System.Xml.XmlElement

            ePolizas = EditarNodo("/PLZ:Polizas")
            ePoliza = CrearNodo("PLZ", "Poliza")
            ePoliza.SetAttribute("NumUnIdenPol", pNum)
            ePoliza.SetAttribute("Fecha", pFecha)
            ePoliza.SetAttribute("Concepto", pConcepto)
            ePolizas.AppendChild(ePoliza)
            InsentarNodo(ePolizas)
        End Sub


        Public Sub AgregaDatosTransaccion(ByVal pNumCta As String, ByVal pConceptoPol As String, ByVal pConcepto As String, ByVal pDebe As Decimal, ByVal pHaber As Decimal, ByVal pMoneda As String, ByVal pTipoCambio As Decimal, ByVal pTipoPoliza As Integer, ByVal pNum As String, ByVal pDesCta As String)
            ' numCta, Concepto, conceptoMovimiento, debe, haber, moneda, 1, tipoPoliza, numIdenPol, desCta
            Dim ePoliza As System.Xml.XmlElement
            Dim eTransaccion As System.Xml.XmlElement

            ePoliza = EditarNodo("/PLZ:Polizas/PLZ:Poliza", pTipoPoliza, pNum)
            eTransaccion = CrearNodo("PLZ", "Transaccion")
            eTransaccion.SetAttribute("NumCta", pNumCta)
            'Descripción Cuenta
            eTransaccion.SetAttribute("DesCta", pDesCta)
            'Revisar que el concepto no venga vacío
            If pConcepto <> "" Then
                eTransaccion.SetAttribute("Concepto", pConcepto)
            Else
                'Si esta vacío, tomar el concepto de la poliza
                eTransaccion.SetAttribute("Concepto", pConceptoPol)
            End If
            eTransaccion.SetAttribute("Debe", pDebe)
            eTransaccion.SetAttribute("Haber", pHaber)

            ePoliza.AppendChild(eTransaccion)
            InsentarNodo(ePoliza)

        End Sub

        Public Sub AgregaDatosComprobantes(ByVal pUUID_CFDI As String, ByVal pMonto As Decimal, ByVal pRFC As String, ByVal pTipoPoliza As Integer, ByVal pNumPoliza As String, ByVal pNumCtaTrans As String, ByVal pConceptoTrans As String)
            Dim Transaccion As System.Xml.XmlElement
            Dim Comprobantes As System.Xml.XmlElement

            Transaccion = EditarNodo("/PLZ:Polizas/PLZ:Poliza", "/PLZ:Transaccion", pTipoPoliza, pNumPoliza, pNumCtaTrans, pConceptoTrans)
            Comprobantes = CrearNodo("PLZ", "Comprobantes")
            Comprobantes.SetAttribute("UUID_CFDI", pUUID_CFDI)
            Comprobantes.SetAttribute("Monto", pMonto)
            Comprobantes.SetAttribute("RFC", pRFC)
            Transaccion.AppendChild(Comprobantes)
            InsentarNodo(Transaccion)
        End Sub

        Private Function CrearNodo(ByVal prefijo As String, ByVal Nombre As String) As System.Xml.XmlNode
            'CrearNodo = m_xmlDOM.CreateNode(XmlNodeType.Element, prefijo, Nombre, "http://www.sat.gob.mx/polizas")
            CrearNodo = m_xmlDOM.CreateNode(XmlNodeType.Element, prefijo, Nombre)
        End Function

        Private Sub InsentarNodo(ByVal Nodo As System.Xml.XmlElement)
            Nodo.AppendChild(m_xmlDOM.CreateTextNode(vbNewLine))
        End Sub

        ' Editar Nodo para las polizas
        Private Function EditarNodo(ByVal Nombre As String) As System.Xml.XmlElement
            Dim doc As XmlDocument = New XmlDocument()
            doc = m_xmlDOM
            Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
            nsmgr.AddNamespace("PLZ", "http://www.sat.gob.mx/polizas")
            'Dim nodeList As XmlNodeList
            Dim root As XmlElement = doc.DocumentElement
            EditarNodo = m_xmlDOM.SelectSingleNode(Nombre, nsmgr)

        End Function

        ' Editar Nodo para Transacciones 
        Private Function EditarNodo(ByVal Nombre As String, ByVal Tipo As Integer, ByVal Num As String) As System.Xml.XmlElement
            Dim doc As XmlDocument = New XmlDocument()
            doc = m_xmlDOM

            Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
            nsmgr.AddNamespace("PLZ", "http://www.sat.gob.mx/polizas")

            Dim nodeList As XmlNodeList
            Dim root As XmlElement = doc.DocumentElement
            nodeList = m_xmlDOM.SelectNodes(Nombre, nsmgr)
            For Each vAuxNode As XmlElement In nodeList
                ' Try
                'Console.WriteLine(vAuxNode.Attributes("NumUnIdenPol").Value)

                If vAuxNode.Attributes("NumUnIdenPol").Value = Num Then
                    EditarNodo = vAuxNode
                    Return EditarNodo
                    'Exit For
                End If
                'Catch ex As Exception
                ' Console.WriteLine(ex.Message.ToString)
                'End Try
            Next vAuxNode
        End Function

        ' Editar Nodo para Comprobantes 
        Private Function EditarNodo(ByVal Nombre As String, ByVal NombreAux As String, ByVal Tipo As Integer, ByVal Num As String, ByVal TransNumCta As String, ByVal TransConcepto As String) As System.Xml.XmlElement
            Dim doc As XmlDocument = New XmlDocument()
            doc = m_xmlDOM
            Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
            nsmgr.AddNamespace("PLZ", "http://www.sat.gob.mx/polizas")

            Dim nodeList As XmlNodeList
            Dim nodeTrans As XmlNodeList
            Dim root As XmlElement = doc.DocumentElement
            nodeList = m_xmlDOM.SelectNodes(Nombre, nsmgr)
            For Each vAuxNode As XmlElement In nodeList
                If vAuxNode.Attributes("NumUnIdenPol").Value = Num Then
                    nodeTrans = vAuxNode.SelectNodes(Nombre & NombreAux, nsmgr)
                    For Each vAuxNodeTrans As XmlElement In nodeTrans
                        If vAuxNodeTrans.Attributes("NumCta").Value = TransNumCta Then ' And vAuxNodeTrans.Attributes("Concepto").Value = TransConcepto Then
                            EditarNodo = vAuxNodeTrans
                            'Exit For
                        End If
                    Next vAuxNodeTrans
                End If
            Next vAuxNode
        End Function

        'Genera el archivo
        Public Sub GeneraArchivos()
            m_xmlDOM.Save("C:\Users\sistemas8\Desktop\FactElectronica123.xml")
        End Sub


    End Class
End Namespace
