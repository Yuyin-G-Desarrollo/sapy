Public Class DepartamentosMaterialesDA

    Public Function getidDepartamentoSicy(ByVal dep As String) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim id As Integer = 0
        Dim consulta As String =
            <cadena>
            select *FROM catalogos where tipcat = 9 and nomcat like 
            </cadena>
        consulta += " '" & dep & "'"
        Dim datos As New DataTable
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            For Each row As DataRow In datos.Rows
                id = row("Idcat")
            Next
        End If
        Return id
    End Function
    Public Function getDepartamentosMateriales(ByVal id As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datosNaves As New DataTable
        Dim consulta As String =
            <cadena>
            select dept_iddepto 'Código',dept_departamento'Departamento',nave_nombre 'Nave',nave_naveid'idNave',dept_status 'Activo' from Materiales.departamentos join Framework.Naves on dept_nave=nave_naveid
            </cadena>
        If id > 0 Then
            consulta += " where dept_iddepto =" & id
        Else
            datosNaves = ListaNavesSegunUsuario()
            consulta += " where dept_nave=0 "
            For Each row As DataRow In datosNaves.Rows
                consulta += " or dept_nave=" & row("nave_naveid")
            Next
            consulta += " order by dept_departamento asc"
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function updateDepartamentosMateriales(ByVal idDep As Integer, ByVal idNave As Integer, ByVal nombre As String, ByVal status As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            update Materiales.departamentos set dept_nave=
            </cadena>
        consulta += " " & idNave & ",dept_departamento='" & nombre & "' ,dept_status=" & status & ", dept_idsicy=" & getidDepartamentoSicy(nombre) & "  where dept_iddepto =" & idDep
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function insertDepartamentosMateriales(ByVal idNave As Integer, ByVal departamento As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            insert into Materiales.departamentos(dept_nave,dept_bepartamento,dept_status,dept_idsicy)
            </cadena>
        consulta += " values(" & idNave & ",'" & departamento & "',1," & getidDepartamentoSicy(departamento) & ")"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function ListaNavesSegunUsuario() As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT nave_naveid, UPPER(nave_nombre) as nave_nombre, upper(nave_navesicyid) as nave_navesicyid FROM Framework.Naves AS b JOIN Framework.NavesUsuario as c on (b.nave_naveid=naus_naveid)"
        consulta += " where naus_usuarioid=" & Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        consulta += " ORDER BY nave_nombre"
        Return opereciones.EjecutaConsulta(consulta)
    End Function
    Public Function validarNombreDepartamento(ByVal idNave As Integer, ByVal departamento As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
             select * from Materiales.departamentos where 
            </cadena>
        consulta += " dept_departamento like '" & departamento & "' and dept_nave=" & idNave
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function validarNombreDepartamentoEditado(ByVal idNave As Integer, ByVal departamento As String, ByVal idDepto As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select * from Materiales.departamentos where 
            </cadena>
        consulta += " dept_departamento like '" & departamento & "' and dept_nave=" & idNave & " and dept_iddepto <> " & idDepto
        Return operaciones.EjecutaConsulta(consulta)
    End Function
End Class
