Imports System.Data.OleDb

Public Class CargaBasesSimulacionForm



    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        If uccFechaIni.Value >= uccFechaFin.Value Then
            MessageBox.Show("La fecha fin debe ser mayor a la fecha inicio", "SAYERP")
        End If
        opCargaExcel.Filter = "Excel Files|*.xlsx"
        If opCargaExcel.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim ruta, resultado As String
            Dim hojas, archivo As DataTable
            Dim objCargaBasesBU As Programacion.Negocios.CargaSimulacionBU = New Negocios.CargaSimulacionBU
            Dim tb As DataTable
            ruta = opCargaExcel.FileName
            txtArchivo.Text = opCargaExcel.FileName.ToString()
            resultado = ""
            txtLogErrores.Text = ""
            hojas = obtenerHojasExcel(ruta)
            Try
                archivo = obtenerDatosHojaExcel(ruta, hojas.Rows(0)("TABLE_NAME"))
            Catch ex As Exception
                'Hoja1$
                archivo = obtenerDatosHojaExcel(ruta, "Hoja1$")
            End Try

            resultado = objCargaBasesBU.ValidarArchivo(archivo)
            If resultado <> "" Then
                txtLogErrores.Text = resultado
                MessageBox.Show("Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente", "SAYERP")
                Exit Sub
            End If

            resultado = objCargaBasesBU.InsertarHomaNaveTallaBase(archivo, cmbBase.ValueMember, uccFechaIni.Value, uccFechaFin.Value)
            If resultado = "" Then
                tb = objCargaBasesBU.InsertarBaseSimulacion(uccFechaIni.Value, uccFechaFin.Value)
                grdBase.DataSource = tb
                MessageBox.Show("La carga se generó correctamente", "SAYERP")
            End If

        End If
    End Sub


    Private Sub CargaBasesSimulacionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargaComboCatalogo()
        uccFechaIni.Value = Today.Date
        uccFechaFin.Value = Today.Date.AddYears(1)

    End Sub

    Private Sub CargaComboCatalogo()
        Dim objCargaBasesBU As Programacion.Negocios.CargaSimulacionBU = New Negocios.CargaSimulacionBU
        Dim dtCatalogo As DataTable = objCargaBasesBU.CargaCatalogoBases()
        cmbBase.DataSource = dtCatalogo
        cmbBase.DisplayMember = "cbs_descripcion"
        cmbBase.ValueMember = "cbs_BaseId"
        objCargaBasesBU = Nothing
    End Sub
    Public Function obtenerHojasExcel(ByVal rutaExcel As String) As DataTable
        Dim cnn As New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaExcel + ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
        cnn.Open()
        Dim dtSheets As DataTable = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        cnn.Close()
        Return dtSheets
    End Function
    Public Function obtenerDatosHojaExcel(ByVal rutaExcel As String, ByVal hoja As String) As DataTable
        Dim cnn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim datos As New DataTable
        cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaExcel + ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandText = "SELECT * FROM [" + hoja + "]"
        cmd.CommandType = CommandType.Text
        da.SelectCommand = cmd
        da.Fill(datos)
        cnn.Close()
        Return datos
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtLogErrores.Text = ""
        grdBase.DataSource = Nothing
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Dim tb As DataTable
        Dim objCargaBasesBU As Programacion.Negocios.CargaSimulacionBU = New Negocios.CargaSimulacionBU
        tb = objCargaBasesBU.ConsultarInformacionPeriodo(uccFechaIni.Value, uccFechaFin.Value)
        grdBase.DataSource = tb
    End Sub
End Class