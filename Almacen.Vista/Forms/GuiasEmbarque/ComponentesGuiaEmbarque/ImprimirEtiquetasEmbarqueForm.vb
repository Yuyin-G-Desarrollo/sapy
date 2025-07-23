Imports System.Data.OleDb
Imports System.IO
Imports Almacen.Negocios
Imports Tools
Imports Tools.Utilerias

Public Class ImprimirEtiquetasEmbarqueForm
    Public Cliente As String
    Public Embarquesid As String
    Dim objInstancia As New AdministradorDocumentosBU
    Dim CarpetaUbicacionArchivos As String = "C:\SAY\"
    Dim RutaArchivoEtiquetas As String = "C:\SAY\\ETIQUETAS.txt"
    Dim RutaArchivoBat As String = "C:\SAY\\Etiquetas.bat"
    Dim datoszapateriaStylo As New DataTable
    Public tipoEmbarque As String
    Private Sub ImprimirEtiquetasEmbarqueForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarImpresoras()

        If Cliente = "ZAPATERIA STYLO" Or Cliente = "ZAPATERIA STYLO (M,G)" Or Cliente = "BODESA S.A.P.I. DE C.V. (LA MARINA)" Or Cliente = "BODESA S.A.P.I. DE C.V. (LA MARINA) (M,G)" Or Cliente = "GRUPO FAMSA S.A. B. DE C.V." Or Cliente = "VEROCHI S.A DE C.V." Then
            rdEspecial.Visible = True
        Else
            rdEspecial.Visible = False
        End If

        If rdEspecial.Checked Then

            If Cliente = "ZAPATERIA STYLO" Or Cliente = "ZAPATERIA STYLO (M,G)" Then
                lblArchivo.Visible = True
                txtarchivo.Visible = True
                btnarchivo.Visible = True
            End If
        End If

        txtnumero.Text = Cliente
    End Sub

    Private Sub CargarImpresoras()
        Dim DTImpresoras = objInstancia.ListaImpresoras()
        cmbImpresoras.DataSource = DTImpresoras
        cmbImpresoras.DisplayMember = "Nombre"
        cmbImpresoras.ValueMember = "IdImpresora"
    End Sub

    Private Sub leerInformacionZapateriaStylo()

        Cursor = Cursors.WaitCursor
        datoszapateriaStylo = importarExcel()
        If datoszapateriaStylo.Rows.Count > 0 Then
            Utilerias.show_message(TipoMensaje.Exito, "Se cargo el archivo corectamente")
        Else
            Utilerias.show_message(TipoMensaje.Exito, "Ocurrio un error no se cargo el archivo")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Function importarExcel() As DataTable

        Dim myFileDialog As New OpenFileDialog()
        Dim xSheet As String = ""
        Dim listahojas As New List(Of Entidades.SheetsExcel)
        Dim nombrehoja As String
        Dim ds As New DataSet
        Dim da As OleDbDataAdapter
        Dim dt As New DataTable
        Dim conn As OleDbConnection

        With myFileDialog
            .Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            .Title = "Open File"
            .ShowDialog()
        End With

        If myFileDialog.FileName.ToString <> "" Then
            Dim ExcelFile As String = myFileDialog.FileName.ToString

            txtarchivo.Text = ExcelFile

            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet

            xlWorkBook = xlApp.Workbooks.Open(ExcelFile) 'ej "D:\prueba.xls

            If xlWorkBook.Worksheets.Count > 1 Then
                For index = 1 To xlWorkBook.Worksheets.Count
                    Dim hoja As New Entidades.SheetsExcel
                    xlWorkSheet = xlWorkBook.Worksheets(index)
                    hoja.NombreHoja = xlWorkSheet.Name
                    hoja.Numero = index
                    listahojas.Add(hoja)
                Next
                Dim instancia As New HojasExcelForm
                instancia.hojas = listahojas
                instancia.ShowDialog()
                nombrehoja = instancia.numeroHoja
            Else
                Dim xlWorkSheetv2 As Microsoft.Office.Interop.Excel.Worksheet
                xlWorkSheetv2 = xlWorkBook.Worksheets(1)
                nombrehoja = xlWorkSheetv2.Name
            End If

            xlApp.Workbooks.Close()





            conn = New OleDbConnection(
                          "Provider=Microsoft.ACE.OLEDB.12.0;" &
                          "data source=" & ExcelFile & "; " &
                         "Extended Properties='Excel 12.0 Xml;HDR=NO;IMEX=1'")

            Try
                da = New OleDbDataAdapter("SELECT * FROM  [" + nombrehoja + "$]", conn)

                conn.Open()
                da.Fill(dt)

                Return dt

                conn.Close()
            Catch ex As Exception

            Finally
                conn.Close()
            End Try
        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "No seleccionaste un archivo")
            Return dt
        End If
        Return dt
    End Function

    Private Sub btnarchivo_Click(sender As Object, e As EventArgs) Handles btnarchivo.Click

        leerInformacionZapateriaStylo()
    End Sub
    Private Sub GenerarImpresion(ByVal datos As DataTable, ByVal impresoraID As Integer)

        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim EtiquetasAImprimir As String = String.Empty

        Try

            Cursor = Cursors.WaitCursor

            strStreamW = CrearRutasArchivo(CarpetaUbicacionArchivos, RutaArchivoEtiquetas)
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

            For Each FILA As DataRow In datos.Rows
                EtiquetasAImprimir &= FILA.Item(0)
            Next

            strStreamWriter.WriteLine(EtiquetasAImprimir)
            strStreamWriter.Close()

            GenerarArchivoBat(impresoraID)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
            'show_message("Error", "Ocurrio un error al generar el archivo, vuelva a intentar.")
        End Try

    End Sub
    Private Function CrearRutasArchivo(ByVal Carpeta As String, ByVal Archivo As String) As Stream
        Dim strStreamW As Stream = Nothing

        Try
            If System.IO.Directory.Exists(Carpeta) = False Then
                System.IO.Directory.CreateDirectory(Carpeta)
            End If

            If File.Exists(Archivo) Then
                File.Delete(Archivo)
                strStreamW = File.Create(Archivo)
            Else
                strStreamW = File.Create(Archivo)
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return strStreamW

    End Function

    Private Sub GenerarArchivoBat(ByVal impresoraid As Integer)
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim PathArchivo As String
        Dim dtArchivo As DataTable


        Try
            Cursor = Cursors.WaitCursor

            dtArchivo = objInstancia.ComandosImprimirEtiquetaGuiasEmbarque(impresoraid)

            If System.IO.Directory.Exists(CarpetaUbicacionArchivos) = False Then
                System.IO.Directory.CreateDirectory(CarpetaUbicacionArchivos)
            End If

            PathArchivo = RutaArchivoBat ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                File.Delete(PathArchivo)
                strStreamW = File.Create(PathArchivo)
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each FILA As DataRow In dtArchivo.Rows
                strStreamWriter.WriteLine(FILA.Item(0))
            Next

            strStreamWriter.Close() ' cerrar
            'Ejecutar el archivo bat
            Shell(RutaArchivoBat)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
            'show_message("Error", "Ocurrio un error al generar el archivo, vuelva a intentar.")
        End Try
    End Sub
    Private Function insertarSatos() As String
        Dim vXmlCeldasModificadas As XElement = New XElement("Codigos")

        For Each row As DataRow In datoszapateriaStylo.Rows
            Dim vNodo As XElement = New XElement("Codigo")
            vNodo.Add(New XAttribute("modelo", row.Item("F1")))
            vNodo.Add(New XAttribute("numeroProveedor", row.Item("F2")))
            vNodo.Add(New XAttribute("RazonSocial", row.Item("F3")))
            vNodo.Add(New XAttribute("codigoBarras", row.Item("F4")))
            vNodo.Add(New XAttribute("tienda", row.Item("F5")))
            vNodo.Add(New XAttribute("fechaCreacion", row.Item("F7")))
            vNodo.Add(New XAttribute("descripcion", row.Item("F6")))

            'vNodo.Add(New XAttribute("posicion", posicion))
            vXmlCeldasModificadas.Add(vNodo)

        Next
        Dim resul As String
        resul = vXmlCeldasModificadas.ToString
        Return resul
    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim result As DataTable
        Dim etiqueta As Integer
        If rdTodos.Checked Then
            etiqueta = 1
        ElseIf rdOtros.Checked Then
            etiqueta = 2
        ElseIf rdEspecial.Checked Then
            etiqueta = 3
        End If


        If Cliente = "ZAPATERIA STYLO" Or Cliente = "ZAPATERIA STYLO (M,G)" And etiqueta = 3 Then
            If txtarchivo.Text = "" Then
                Utilerias.show_message(TipoMensaje.Advertencia, "Este cliente necesita el archivo que contenga la informacion de las etiquetas")
                Return
            End If
        End If

        Dim impresora = cmbImpresoras.SelectedValue

        Try
            If impresora <> 0 Then

                If tipoEmbarque = 0 Then
                    If (Cliente = "ZAPATERIA STYLO" Or Cliente = "ZAPATERIA STYLO (M,G)") And etiqueta = 3 Then
                        Dim vXmlCeldasModificadas = insertarSatos()
                        result = objInstancia.ConsultarEtiquetasZapatoStylo(vXmlCeldasModificadas, impresora)
                    Else
                        result = objInstancia.ConsultarEtiquetasEmbarque(0, Embarquesid, impresora, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, etiqueta)
                    End If
                Else
                    result = objInstancia.ConsultarEtiquetasOtrosEmbarque(0, Embarquesid, etiqueta, impresora, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                End If
                GenerarImpresion(result, impresora)
                objInstancia.InsertarBitacoraImprecionGE(0, Embarquesid, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                Utilerias.show_message(TipoMensaje.Exito, "Se mandaron a imprimir las etiquetas correctamente")
                Me.Close()
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "No seleccionaste una impresora las etiquetas no se imprimieron")
            End If
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un Error no se mandaron a imprimir las etiquetas")
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub rdOtros_CheckedChanged(sender As Object, e As EventArgs) Handles rdOtros.CheckedChanged
        lblArchivo.Visible = False
        txtarchivo.Visible = False
        btnarchivo.Visible = False
    End Sub

    Private Sub rdEspecial_CheckedChanged(sender As Object, e As EventArgs) Handles rdEspecial.CheckedChanged
        If rdEspecial.Checked Then

            If Cliente = "ZAPATERIA STYLO" Or Cliente = "ZAPATERIA STYLO (M,G)" Then
                lblArchivo.Visible = True
                txtarchivo.Visible = True
                btnarchivo.Visible = True
            End If
        End If
    End Sub


    Private Sub rdTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdTodos.CheckedChanged
        lblArchivo.Visible = False
        txtarchivo.Visible = False
        btnarchivo.Visible = False
    End Sub
End Class