Public Class TiposMaterialesDA
    Public Function getTiposMateriales(ByVal id As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select tima_idTipo 'Código',tima_tipoMaterial 'Tipo',tima_status 'Activo' from Materiales.TiposMateriales
            </cadena>
        If id > 0 Then
            consulta += " where tima_idTipo =" & id
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function updateTiposMateriales(ByVal id As Integer, ByVal nombre As String, ByVal status As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            update Materiales.TiposMateriales set tima_tipoMaterial=
            </cadena>
        consulta += "'" & nombre & "', tima_status=" & status & "  where tima_idTipo=" & id
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function insertTiposMateriales(ByVal nombre As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
           insert into Materiales.TiposMateriales(tima_tipoMaterial,tima_status) values
            </cadena>
        consulta += "('" & nombre & "',1)"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function verificarTiposMateriales(ByVal nombre As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select tima_idTipo 'Código',tima_tipoMaterial 'Tipo',tima_status 'Activo' from Materiales.TiposMateriales
            </cadena>
        consulta += " where tima_tipoMaterial like '" & nombre & "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
End Class
