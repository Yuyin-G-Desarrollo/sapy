Public Class UnidadDeMedidaMaterialesDA
    Public Function getUnidadesMedidas(ByVal id As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select unme_idunidad 'Código',unme_descripcion 'Unidad de Medida',unme_status 'Activo' from Materiales.UnidadDeMedida
            </cadena>
        If id > 0 Then
            consulta += " where unme_idunidad =" & id
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function updateUnidadesMedidas(ByVal id As Integer, ByVal nombre As String, ByVal status As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            update Materiales.UnidadDeMedida set unme_descripcion=
            </cadena>
        consulta += "'" & nombre & "', unme_status=" & status & "  where unme_idunidad =" & id
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function insertUnidadesMedidas(ByVal nombre As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            insert into Materiales.UnidadDeMedida(unme_descripcion,unme_status) values
            </cadena>
        consulta += "('" & nombre & "',1)"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function verificarUnidadesMedidas(ByVal des As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select unme_idunidad 'Código',unme_descripcion 'Unidad de Medida',unme_status 'Activo' from Materiales.UnidadDeMedida
            </cadena>
        consulta += " where unme_descripcion like '" & des & "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
End Class
