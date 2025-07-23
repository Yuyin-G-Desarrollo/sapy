Imports Stimulsoft.Report
Imports System.Net

Public Class RemisionBU
    'Private ftp As String = "ftp://192.168.7.16"
    Private rutaRemisiones As String = "Administracion/ConfiguracionEmpresas/REMISIONES/"
    Private rutaArchivosTemp As String = "C:\RespaldosXml\Remisiones\"
    Public guidTemp As Guid = Nothing

    Public Function generarPdf(ByVal remision As Entidades.Remision, ByVal cliente As Entidades.ClientesCFDI, ByVal conceptos As List(Of Entidades.Conceptos)) As Boolean
        Try
            Dim sucursal As New Entidades.SucursalesFacturacion
            Dim objSucursal As New SucursalesBU
            sucursal = objSucursal.getDatosSucursal(remision.RSucursalId)
            Dim objReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            Dim reporte As New StiReport
            Dim pdfSettings = New StiPdfExportSettings()
            EntidadReporte = objReporte.LeerReporte(sucursal.SReporteRemision)
            Dim archivo As String = rutaArchivosTemp & EntidadReporte.Pnombre.Trim & ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim dtConcepto = New DataTable("Conceptos")
            Dim cantidadLetra As String
            Dim auxcantidadLetra() As String
            Dim sPDF As String = String.Empty
            Dim rutaPDF As String = String.Empty
            Dim objUtilerias As New UtileriasBU
            Dim localizacion(3) As String


            localizacion = objUtilerias.obtenerLocalizacion(sucursal.SCiudadid)
            sPDF = rutaArchivosTemp & sucursal.SNombre & "\" & remision.RFecha.ToString("MMyyyy") & "\" & remision.RFecha.ToString("yyyy") & remision.RFolio.ToString("00000") & ".pdf"
            rutaPDF = rutaRemisiones & sucursal.SNombre & "/" & remision.RFecha.ToString("MMyyyy") & "/"

            If Not existeCarpetaTemp(System.IO.Path.GetDirectoryName(sPDF)) Then
                Return False
                Exit Function
            End If

            reporte.Load(archivo)
            reporte.Compile()
            reporte("rutaImagen") = descargarArchivo(sucursal.SLogo)
            reporte("Sucursal") = sucursal.SNombre
            reporte("DomicilioCalleNumCol") = sucursal.SCalle & " No." & sucursal.SNumero & ", Col. " & sucursal.SColonia & ","
            reporte("DomicilioCpCdEdoTel") = "CP.: " & sucursal.SCp & ", " & localizacion(0) & ", " & localizacion(1) & ", " & localizacion(2)
            reporte("Folio") = remision.RFolio
            reporte("Fecha") = CDate(remision.RFecha.ToString("dd/MM/yyyy"))

            reporte("Cliente") = cliente.CNombreRemision
            reporte("DomicilioCliente") = cliente.CCalle & " No." & cliente.CNumeroExterior & " " & cliente.CNumeroExterior & ". COL. " & cliente.CColonia
            reporte("Observacion") = remision.RObservacion
            reporte("Subtotal") = remision.RSubtotal

            If remision.RDescuento <> 0 Then
                reporte("lblDescuento") = "DESCUENTO"
                reporte("Descuento") = remision.RDescuento.ToString("C2")
            End If

            reporte("Total") = remision.RTotal

            cantidadLetra = objUtilerias.EnLetras(remision.RTotal.ToString()).ToUpper
            auxcantidadLetra = Split(cantidadLetra, " CON ")
            If auxcantidadLetra.Length = 1 Then
                cantidadLetra = "(" & auxcantidadLetra(0) & " PESOS 00/100 M.N.)"
            Else
                cantidadLetra = "(" & auxcantidadLetra(0) & " PESOS " & auxcantidadLetra(1) & "/100 M.N.)"
            End If
            reporte("TotalLetra") = cantidadLetra


            With dtConcepto
                .Columns.Add("Cantidad")
                .Columns.Add("Unidad")
                .Columns.Add("Descripcion")
                .Columns.Add("PrecioUnitario")
                .Columns.Add("Importe")
            End With

            For Each concepto In conceptos
                dtConcepto.Rows.Add( _
                    concepto.CCantidad, _
                    concepto.CUnidad, _
                    concepto.CDescripcion, _
                    concepto.CValorUnitario, _
                    concepto.CImporte _
                )
            Next
            reporte.RegData(dtConcepto)

            'reporte.Show()
            reporte.Render()
            reporte.ExportDocument(StiExportFormat.Pdf, sPDF, pdfSettings)
            reporte.Dispose()

            If subirFtp(rutaPDF, sPDF) Then
                Dim objRemision As New Datos.WebRemisionDA
                remision.RReporteId = sucursal.SReporteRemision
                'remision.RPdf = ftp.ToUpper & "/" & rutaPDF.ToUpper & System.IO.Path.GetFileName(sPDF)
                remision.RPdf = rutaPDF.ToUpper & System.IO.Path.GetFileName(sPDF)

                objRemision.actualizaRutaPDF(remision)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function descargarArchivo(ByVal archivo As String) As String
        Try
            Dim objFTP As New TransferenciaFTPBU
            Dim request = DirectCast(WebRequest.Create(ftpUrl), FtpWebRequest)
            Dim rutaArchivo As String = ""
            Dim nuevaRuta As String = ""
            request.Credentials = New NetworkCredential(user, pass)

            If archivo <> "" Then
                'archivo = archivo.ToUpper.Replace(ftp.ToUpper, "")
                rutaArchivo = IO.Path.GetDirectoryName(archivo)
                objFTP.DescargarArchivo(rutaArchivo, rutaArchivosTemp & guidTemp.ToString, IO.Path.GetFileName(archivo))
                nuevaRuta = rutaArchivosTemp & guidTemp.ToString & "\" & IO.Path.GetFileName(archivo)
            End If

            Return nuevaRuta
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function subirFtp(ByVal ruta As String, ByVal archivo As String) As Boolean
        Try
            Dim objFTP As New TransferenciaFTPBU
            Dim request = DirectCast(WebRequest.Create(ftpUrl), FtpWebRequest)

            request.Credentials = New NetworkCredential(user, pass)
            objFTP.EnviarArchivo(ruta, archivo)

            Dim srtRuta As String = ftpUrl & "/" & ruta & "/" & IO.Path.GetFileName(archivo)
            If objFTP.FtpExisteArchivo(srtRuta) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function existeCarpetaTemp(ByVal ruta As String) As Boolean
        Try
            Dim existe As Boolean
            existe = System.IO.Directory.Exists(ruta)

            If Not existe Then
                System.IO.Directory.CreateDirectory(ruta)
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
