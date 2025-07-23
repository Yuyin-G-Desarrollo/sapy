Imports System.IO

Public Class AnexarArchivosDocumentosExternosForm

    Dim objFacturasBu As Facturacion.Negocios.TimbradoBU
    Dim ObjDocumentosBU As New Negocios.AdministradorDocumentosBU
    Public entCliente As Entidades.Cliente
    Public DocumentoID As Integer
    Public TotalFactura As Double

    Private Sub AnexarArchivosDocumentosExternosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblClienteNombre.Text = entCliente.nombregenerico
        lblIdDocumento.Text = DocumentoID
    End Sub

    Private Sub btnExaminarPDF_Click(sender As Object, e As EventArgs) Handles btnExaminarPDF.Click
        ofdRutaArchivo.Reset()
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "PDF|*.pdf;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txtArchivoPDF.Text = ofdRutaArchivo.FileName
    End Sub

    Private Sub btnExaminarXML_Click(sender As Object, e As EventArgs) Handles btnExaminarXML.Click
        ofdRutaArchivo.Reset()
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "XML|*.xml;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txtArchivoXML.Text = ofdRutaArchivo.FileName
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Dim dtRutas As DataTable
        'Dim CarpetaAnio As String
        'Dim RutaPDF As String
        'Dim RutaXML As String
        'Dim RutaLocalPDF As String
        'Dim RutaLocalXML As String
        'Dim SplitRutaLocalPDF() As String
        'Dim SplitRutaLocalXML() As String
        'Dim NombreArchivoPDF As String
        'Dim NombreArchivoXML As String
        'Dim RutaCompletaPDF As String
        'Dim RutaCompletaXML As String

        ''validar campos vacios
        'If txtArchivoPDF.Text = String.Empty Or txtArchivoXML.Text = String.Empty Then
        '    show_message("Advertencia", "Faltan de capturar campos obligatorios.")
        '    Return
        'End If

        ''copiar archvios en la ruta
        'Try
        '    CarpetaAnio = Date.Now.ToString("MMyyyy")

        '    RutaLocalPDF = txtArchivoPDF.Text
        '    RutaLocalXML = txtArchivoXML.Text

        '    dtRutas = ObjDocumentosBU.ObtenerRutas_PDF_XML_DocumentoExtanjero(DocumentoID)

        '    If dtRutas.Rows.Count > 0 Then

        '        objFacturasBu = New Facturacion.Negocios.TimbradoBU(CInt(dtRutas.Rows(0).Item("EmpresaID")), False)

        '        If Not objFacturasBu.ValidarMontoFacturaExterno(RutaLocalXML, TotalFactura) Then
        '            show_message("Advertencia", "Favor de verificar que el monto de archivo XML coincida con el de la factura seleccionada.")
        '            Return
        '        End If

        '        RutaPDF = dtRutas.Rows(0).Item("RutaPDF").ToString + CarpetaAnio
        '        RutaXML = dtRutas.Rows(0).Item("RutaXML").ToString + CarpetaAnio

        '        If Not System.IO.Directory.Exists(RutaPDF) Then
        '            Directory.CreateDirectory(RutaPDF)
        '        End If

        '        If Not System.IO.Directory.Exists(RutaXML) Then
        '            Directory.CreateDirectory(RutaXML)
        '        End If

        '        SplitRutaLocalPDF = Split(RutaLocalPDF, "\")
        '        SplitRutaLocalXML = Split(RutaLocalXML, "\")

        '        NombreArchivoPDF = SplitRutaLocalPDF(SplitRutaLocalPDF.Length - 1)
        '        NombreArchivoXML = SplitRutaLocalXML(SplitRutaLocalXML.Length - 1)

        '        RutaCompletaPDF = RutaPDF + "\" + NombreArchivoPDF
        '        RutaCompletaXML = RutaXML + "\" + NombreArchivoXML

        '        If File.Exists(RutaCompletaPDF) Then
        '            show_message("Advertencia", "El archivo PDF ya existe en la ruta destino, intente renombrar el archivo y anexar nuevamente")
        '            Return
        '        End If

        '        If File.Exists(RutaCompletaXML) Then
        '            show_message("Advertencia", "El archivo XML ya existe en la ruta destino, intente renombrar el archivo y anexar nuevamente")
        '            Return
        '        End If

        '        File.Copy(RutaLocalPDF, RutaCompletaPDF)
        '        File.Copy(RutaLocalXML, RutaCompletaXML)

        '        'ejecutar function ObtenerDatosDelComplemento
        '        objFacturasBu.ObtenerDatosDelComplementoExterno(DocumentoID, RutaCompletaXML, "", "FACTURACALZADO")

        '        'actualizar tabla con las rutas
        '        ObjDocumentosBU.GuardarRutaFacturaDocumentosExternos(DocumentoID, RutaCompletaPDF, RutaCompletaXML)

        '        show_message("Exito", "Se anexaron correctamente los archivos PDF y XML")
        '        Me.Close()
        '    Else
        '        Return
        '    End If

        'Catch ex As Exception
        '    show_message("Error", ex.Message)
        '    Return
        'End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
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


        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

    End Sub


End Class