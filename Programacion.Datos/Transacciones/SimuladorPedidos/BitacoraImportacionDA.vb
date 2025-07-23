Public Class BitacoraImportacionDA
    Public Function Agregar(tipo As String, nota As String) As Int32
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Sql As String = "insert into programacion.bitacoraImportacion (bimp_tipo,bimp_nota) values('" & tipo & "','" & nota & "')"
        Return operaciones.EjecutaSentencia(Sql)
    End Function

    Public Function Tabla() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta("select convert(varchar(10),bimp_fecha, 103) + ' '+ right(convert(varchar(32),bimp_fecha,108),8) Fecha,UPPER(bimp_pc) PC,UPPER(bimp_tipo) Tipo,bimp_nota Nota from Programacion.BitacoraImportacion order by 1 desc")
    End Function
End Class
