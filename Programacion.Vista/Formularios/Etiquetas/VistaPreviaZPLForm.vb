Imports System.Net
Imports System.IO
Imports System.Text
Imports DevExpress.XtraBars.Docking2010

Public Class VistaPreviaZPLForm

    Public CodigoZPL200 As String = String.Empty
    Public CodigoZPL300 As String = String.Empty
    Public CodigoZPLVistaPrevia As String = String.Empty
    Public CodigoZPLVistaPravia300 As String = String.Empty
    Public AnchoEtiqueta As String = String.Empty
    Public AltoEtiqueta As String = String.Empty
    Public Cliente As String = String.Empty
    Public tipoEtiqueta As String = String.Empty
    Public clienteId As Integer = 0
    Public etiquetaId As Integer = 0
    Public RutaFoto As String = String.Empty
    Public RutaFoto300 As String = String.Empty
    Public StatusEtiquetaID As Integer = 0
    Private RutaLogoCliente As String = String.Empty
    Public FechaModificacionEtiqueta As Date
    Public UsuarioModifico As String = String.Empty
    Public LogoCliente203 As String = String.Empty
    Public LogoCliente300 As String = String.Empty
    Public LogoFleje203 As String = String.Empty
    Public LogoFleje300 As String = String.Empty
    Public RutaLogoFleje203 As String = String.Empty
    Public RutaLogoFleje300 As String = String.Empty

    Dim msgError As New Tools.ErroresForm
    Dim msgAdvertencia As New Tools.AdvertenciaForm
    Dim msgExito As New Tools.ExitoForm
    Public ListaImagenes As New List(Of String)

    Private Sub VistaPreviaZPLForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objBu As New Programacion.Negocios.EtiquetasBU
        Dim dt As DataTable
        Diseño(pcbt203dpi)
        Diseño(pctb300dpi)
        Diseño(pctbVistaPrevia)
        txtCliente.Text = Cliente
        txtAlto.Text = AltoEtiqueta
        txtAncho.Text = AnchoEtiqueta
        txtTipo.Text = tipoEtiqueta

        If rdo300.Checked = True Then
            dt = objBu.VistaPrevia(etiquetaId, clienteId, StatusEtiquetaID, "300dpi", Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
        Else
            dt = objBu.VistaPrevia(etiquetaId, clienteId, StatusEtiquetaID, "203dpi", Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
        End If

        If Not IsNothing(dt) Then
            If dt.Rows.Count > 0 Then
                CodigoZPLVistaPrevia = dt.Rows(0).Item("Zpl").trim.ToString
                RutaFoto = dt.Rows(0).Item("Foto").trim.ToString
                RutaFoto300 = dt.Rows(0).Item("Silueta300").trim.ToString
                RutaLogoCliente = dt.Rows(0).Item("Logo").trim.ToString
                CodigoZPLVistaPravia300 = dt.Rows(0).Item("ZPL300").trim.ToString
                LogoCliente203 = dt.Rows(0).Item("LogoCliente203").trim.ToString
                LogoCliente300 = dt.Rows(0).Item("LogoCliente300").trim.ToString
                RutaLogoFleje203 = dt.Rows(0).Item("Fleje203").trim.ToString
                RutaLogoFleje300 = dt.Rows(0).Item("Fleje300").trim.ToString
            End If
        End If
        MostrarZPL()
    End Sub

    Private Sub MostrarZPL()
        Dim ruta As String = String.Empty
        If CodigoZPL200 <> String.Empty Then
            ruta = ObtenerImagenZPL(CodigoZPL200, "200")
            CargarImagen(pcbt203dpi, ruta)
        End If
        ruta = Nothing
        If CodigoZPL300 <> String.Empty Then
            ruta = ObtenerImagenZPL(CodigoZPL300, "300")
            CargarImagen(pctb300dpi, ruta)
        End If
        If CodigoZPLVistaPrevia <> String.Empty Then
            ruta = ObtenerImagenZPL(CodigoZPLVistaPrevia, "200")
            CargarImagen(pctbVistaPrevia, ruta)
        End If
    End Sub

    Private Function ObtenerImagenZPL(ByVal ZPL As String, ByVal Resolucion As String) As String
        Dim Imagen As String = String.Empty
        Dim ZPL200() As Byte = Encoding.UTF8.GetBytes(ZPL)
        Dim RutaURL As String = String.Empty
        Dim AnchoPulgadas As Double = 0
        Dim AltoPulgadas As Double = 0

        AnchoPulgadas = Math.Round(CDbl(AnchoEtiqueta) * 0.3937, 2)
        AltoPulgadas = Math.Round(CDbl(AltoEtiqueta) * 0.3937, 2)

        If Resolucion = "200" Then
            RutaURL = "http://api.labelary.com/v1/printers/8dpmm/labels/" & AnchoPulgadas.ToString() & "x" & AltoPulgadas.ToString & "/0/"
        Else
            RutaURL = "http://api.labelary.com/v1/printers/12dpmm/labels/" & AnchoPulgadas & "x" & AltoPulgadas.ToString() & "/0/"
        End If

        Dim request As HttpWebRequest = WebRequest.Create(RutaURL)

        request.Method = "POST"
        ' request.Accept = "application/pdf" ' omit this line to get PNG images back
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = ZPL200.Length

        Dim requestStream As Stream = request.GetRequestStream()
        requestStream.Write(ZPL200, 0, ZPL200.Length)
        requestStream.Close()

        Dim g As Guid
        g = Guid.NewGuid()
        Dim id As String = g.ToString

        Try
            Dim response As HttpWebResponse = request.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream()
            If Directory.Exists("c:\ZPL\") = False Then
                Directory.CreateDirectory("c:\ZPL\")
            End If
            Dim fileStream As Stream = File.Create("c:\ZPL\label_" + id + ".png") ' change file name for PNG images
            responseStream.CopyTo(fileStream)
            responseStream.Close()
            fileStream.Close()
            Imagen = "c:\ZPL\label_" + id + ".png"

            ListaImagenes.Add(Imagen)
        Catch ex As WebException
            'Console.WriteLine("Error: {0}", ex.Status)
            Imagen = "Error: " + ex.Message
        End Try

        Return Imagen
    End Function

    Private Sub CargarImagen(ByVal Control As PictureBox, ByVal ruta As String)

        If Not ruta.Contains("Error") Then
            LiberarImagen(Control)
            Control.Image = Image.FromFile(ruta)
        Else
            'Control()

        End If
    End Sub
    Private Sub CargarImagen(ByVal Control As PictureBox, ByVal imagen As System.Drawing.Bitmap)
        LiberarImagen(Control)
        Control.Image = imagen
    End Sub


    Private Sub LiberarImagen(ByVal Control As PictureBox)
        If Not IsNothing(Control.Image) Then
            Control.Image.Dispose()
            Control = Nothing
        End If
    End Sub
    Private Sub Diseño(ByVal Control As PictureBox)
        Control.BorderStyle = BorderStyle.FixedSingle
        CargarImagen(Control, My.Resources.sin_imagen)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub VistaPreviaZPLForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LiberarImagen(pcbt203dpi)
        LiberarImagen(pctb300dpi)
        LiberarImagen(pctbVistaPrevia)

        Try
            For Each Archivo As String In ListaImagenes
                File.Delete(Archivo)
            Next

            For Each Archivo In Directory.GetFiles("c:\ZPL\TXT\")
                File.Delete(Archivo)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub groupControl1_CustomButtonClick(sender As Object, e As BaseButtonEventArgs) Handles GroupControl1.CustomButtonClick
        Dim CodigoZPLImpresion As String = String.Empty
        Dim Resolucion As String = String.Empty

        Try
            If rdo203.Checked = True Then
                Resolucion = "203dpi"
                CodigoZPLImpresion = AgregarEtiquetaPrueba(Resolucion) + vbCrLf + CodigoZPLVistaPrevia
            Else
                Resolucion = "300dpi"
                CodigoZPLImpresion = AgregarEtiquetaPrueba(Resolucion) + vbCrLf + CodigoZPLVistaPravia300
            End If

            If CodigoZPLVistaPrevia.Trim.Length > 0 Then
                If Directory.Exists("c:\ZPL\TXT\") = False Then
                    Directory.CreateDirectory("c:\ZPL\TXT\")
                End If
                Dim g As Guid
                g = Guid.NewGuid()
                Dim id As String = g.ToString
                Dim ArchivoTxt As String = "c:\ZPL\TXT\Etiquetas_" + id + ".txt"
                Dim fileStream As Stream = File.Create(ArchivoTxt)
                Dim info() As Byte = New UTF8Encoding(True).GetBytes(CodigoZPLImpresion)
                fileStream.Write(info, 0, info.Length)
                fileStream.Close()
                Dim ArchivoBat As String = "c:\ZPL\TXT\Etiquetas_" + id + ".bat"
                fileStream = File.Create(ArchivoBat)
                Dim sw As New System.IO.StreamWriter(fileStream)

                If rdo203.Checked = True Then
                    If RutaFoto <> String.Empty Then
                        sw.WriteLine(RutaFoto)
                    End If

                    If LogoCliente203 <> String.Empty Then
                        sw.WriteLine(LogoCliente203)
                    End If

                    If RutaLogoFleje203 <> String.Empty Then
                        sw.WriteLine(RutaLogoFleje203)
                    End If

                Else
                    If RutaFoto300 <> String.Empty Then
                        sw.WriteLine(RutaFoto300)
                    End If

                    If LogoCliente300 <> String.Empty Then
                        sw.WriteLine(LogoCliente300)
                    End If

                    If RutaLogoFleje300 <> String.Empty Then
                        sw.WriteLine(RutaLogoFleje300)
                    End If

                End If

                
                sw.WriteLine("COPY " + ArchivoTxt + " C:\PRN")
                sw.Close()
                Shell(ArchivoBat)
                'For Each Archivo In Directory.GetFiles("c:\ZPL\TXT\")
                '    File.Delete(Archivo)
                'Next
                'File.Delete(ArchivoTxt)
                'File.Delete(ArchivoBat)
            Else

                msgAdvertencia.mensaje = "No existe codigo ZPL disponible para imprimir."
                msgAdvertencia.ShowDialog()

            End If
        Catch ex As Exception
            msgError.mensaje = ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace
            msgError.ShowDialog()
        Finally

        End Try
    End Sub

    Private Function AgregarEtiquetaPrueba(ByVal Resolucion As String) As String
        Dim ZPL As String = String.Empty
        Dim ValorFechaImpresion As String = String.Empty
        Dim ValorUsuarioImprimio As String = String.Empty
        Dim ValorFechaModificacion As String = String.Empty


        Try
            ValorFechaImpresion = Date.Now.ToString("dd/MM/yyyy HH:mm")
            ValorFechaModificacion = FechaModificacionEtiqueta.ToString("dd/MM/yyyy HH:mm")

            If Resolucion = "203dpi" Then
                ZPL = "CT~~CD,~CC^~CT~" & vbCrLf & _
                       "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ" & vbCrLf & _
                       "^XA" & vbCrLf & _
                        "^MMT" & vbCrLf & _
                        "^PW609" & vbCrLf & _
                        "^LL0406" & vbCrLf & _
                        "^LS0" & vbCrLf & _
                        "^FT13,368^A0N,28,28^FH\^FDF Impresi\A2n:^FS" & vbCrLf & _
                        "^FT168,369^A0N,28,28^FH\^FD" & ValorFechaImpresion.ToString() & "^FS" & vbCrLf & _
                        "^FT137,325^A0N,28,28^FH\^FD" & Entidades.SesionUsuario.UsuarioSesion.PUserUsername & "^FS" & vbCrLf & _
                        "^FT13,325^A0N,28,28^FH\^FDImprimi\A2:^FS" & vbCrLf & _
                        "^FT13,226^A0N,28,28^FH\^FDF Modificaci\A2n:^FS" & vbCrLf & _
                        "^FT13,185^A0N,28,28^FH\^FDModific\A2:^FS" & vbCrLf & _
                        "^FT13,144^A0N,28,28^FH\^FDResoluci\A2n:^FS" & vbCrLf & _
                        "^FT205,225^A0N,28,28^FH\^FD" & ValorFechaModificacion & "^FS" & vbCrLf & _
                        "^FT131,185^A0N,28,28^FH\^FD" & UsuarioModifico & "^FS" & vbCrLf & _
                        "^FT158,144^A0N,28,28^FH\^FD" & Resolucion & "^FS" & vbCrLf & _
                        "^FT186,103^A0N,28,28^FH\^FD" & tipoEtiqueta & "^FS" & vbCrLf & _
                        "^FT110,62^A0N,28,28^FH\^FD" & Cliente & "^FS" & vbCrLf & _
                        "^FT13,103^A0N,28,28^FH\^FDTipo Etiqueta:^FS" & vbCrLf & _
                        "^FT13,62^A0N,28,28^FH\^FDCliente:^FS" & vbCrLf & _
                        "^PQ1,0,1,Y^XZ"

            ElseIf Resolucion = "300dpi" Then
                ZPL = "CT~~CD,~CC^~CT~" & vbCrLf & _
                    "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ" & vbCrLf & _
                    "^XA" & vbCrLf & _
                    "^MMT" & vbCrLf & _
                    "^PW900" & vbCrLf & _
                    "^LL0600" & vbCrLf & _
                    "^LS0" & vbCrLf & _
                    "^FT19,545^A0N,42,43^FH\^FDF Impresi\A2n:^FS" & vbCrLf & _
                    "^FT249,546^A0N,42,43^FH\^FD" & ValorFechaImpresion & "^FS" & vbCrLf & _
                    "^FT202,481^A0N,42,43^FH\^FD" & ValorUsuarioImprimio & "^FS" & vbCrLf & _
                    "^FT19,481^A0N,42,43^FH\^FDImprimi\A2:^FS" & vbCrLf & _
                    "^FT19,335^A0N,42,43^FH\^FDF Modificaci\A2n:^FS" & vbCrLf & _
                    "^FT19,274^A0N,42,43^FH\^FDModific\A2:^FS" & vbCrLf & _
                    "^FT19,213^A0N,42,43^FH\^FDResoluci\A2n:^FS" & vbCrLf & _
                    "^FT303,334^A0N,42,43^FH\^FD" & ValorFechaModificacion & "^FS" & vbCrLf & _
                    "^FT194,274^A0N,42,43^FH\^FD" & UsuarioModifico & "^FS" & vbCrLf & _
                    "^FT233,214^A0N,42,43^FH\^FD" & Resolucion & "^FS" & vbCrLf & _
                    "^FT275,153^A0N,42,43^FH\^FD" & tipoEtiqueta & "^FS" & vbCrLf & _
                    "^FT163,92^A0N,42,43^FH\^FD" & Cliente & "^FS" & vbCrLf & _
                    "^FT19,153^A0N,42,43^FH\^FDTipo Etiqueta:^FS" & vbCrLf & _
                    "^FT19,92^A0N,42,43^FH\^FDCliente:^FS" & vbCrLf & _
                    "^PQ1,0,1,Y^XZ"

            End If
        Catch ex As Exception
            Throw ex
        End Try
        
        Return ZPL

    End Function


End Class