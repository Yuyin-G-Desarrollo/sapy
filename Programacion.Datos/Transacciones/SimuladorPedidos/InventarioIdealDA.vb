Imports System.Data.OleDb

Public Class InventarioIdealDA
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
    Public Sub InicializarTablaExcel()
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sentencia = "truncate table programacion.inventarioidealexcel"
        operaciones.EjecutaSentencia(sentencia)
    End Sub
    Public Sub InsertarExcel(obj As Entidades.InventarioIdeal)

        Dim consulta As New System.Text.StringBuilder
        consulta.Append("INSERT INTO programacion.InventarioIdealExcel (invi_ranking,invi_coleccion,invi_modelo,invi_piel_color,invi_corrida,invi_cantidad) values(")
        consulta.Append("'" & obj.Pranking & "',")
        consulta.Append("'" & obj.Pcoleccion & "',")
        consulta.Append("'" & obj.Pmodelo & "',")
        consulta.Append("'" & obj.Ppiel_color & "',")
        consulta.Append("'" & obj.Pcorrida & "',")
        consulta.Append(obj.Pcantidad & ")")

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        operaciones.EjecutaSentencia(consulta.ToString)

    End Sub
    Public Function obtenerDatosInventarioIdeal() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select invi_ranking Ranking,invi_coleccion Coleccion,invi_modelo Modelo,invi_piel_color PielColor,invi_corrida Corrida,invi_cantidad Cantidad from programacion.InventarioIdealExcel"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
End Class
