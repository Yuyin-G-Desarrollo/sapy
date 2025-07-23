Public Class EspacioReservadoDA
    Public Function TablaFechas(inicio As Date, final As Date, activos As Boolean, cancelados As Boolean, simulados As Boolean, asignado As Boolean, fechas As Boolean, especiales As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim filtro As String = ""
        If activos Then filtro += "'Activo',"
        If cancelados Then filtro += "'Cancelado',"
        If simulados Then filtro += "'Simulado',"
        If asignado Then filtro += "'Asignado',"
        Dim SQL As String
        filtro += "''"
        If operaciones.Servidor = obj.Servidor Then
            SQL = ""
            SQL += " select espa_espaID _ID,espa_fecha Fecha,nombre Cliente,espa_pares Pares,nave_nombre Nave,UPPER ( espa_estatus ) Estatus,espa_fechaCreacion Creacion,user_userName CreadorPor"
            SQL += " from"
            SQL += " Programacion.espacioreservado"
            SQL += " INNER JOIN [" + obj.NombreDB + "].dbo.Cadenas on IdCadena = espa_idcadena inner JOIN Framework.Usuarios on user_usuarioid =espa_usuarioCreoId INNER JOIN Programacion.NavesAux  on nave_naveid  = espa_linpID "
            If especiales Then
                SQL += " inner JOIN Programacion.ClientesEspeciales on idcadena=cesp_idcadena "
            End If


            SQL += " WHERE "
            If fechas Then
                SQL += " espa_fecha BETWEEN '" & inicio.ToShortDateString & "' and '" & final.ToShortDateString & "' and "
            End If
            If especiales Then
                SQL += " activo='S' and "
            End If
            SQL += " espa_estatus in (" & filtro & ")"
            SQL += " ORDER BY _id"
        Else
            SQL = ""
            SQL += " select espa_espaID _ID,espa_fecha Fecha,nombre Cliente,espa_pares Pares,nave_nombre Nave,UPPER ( espa_estatus ) Estatus,espa_fechaCreacion Creacion,user_userName CreadorPor"
            SQL += " from"
            SQL += " Programacion.espacioreservado"
            SQL += " INNER JOIN [" + obj.Servidor + "].[" + obj.NombreDB + "].dbo.Cadenas on IdCadena = espa_idcadena inner JOIN Framework.Usuarios on user_usuarioid =espa_usuarioCreoId INNER JOIN Programacion.NavesAux  on nave_naveid  = espa_linpID "
            If especiales Then
                SQL += " inner JOIN Programacion.ClientesEspeciales on idcadena=cesp_idcadena "
            End If


            SQL += " WHERE "
            If fechas Then
                SQL += " espa_fecha BETWEEN '" & inicio.ToShortDateString & "' and '" & final.ToShortDateString & "' and "
            End If
            If especiales Then
                SQL += " activo='S' and "
            End If
            SQL += " espa_estatus in (" & filtro & ")"
            SQL += " ORDER BY _id"
        End If
       
        Return operaciones.EjecutaConsulta(SQL)
    End Function

    Public Function obtenerClientes(ByVal especiales As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        If operaciones.Servidor = obj.Servidor Then
            consulta = "select idCadena,Nombre from [" + obj.NombreDB + "].dbo.Cadenas inner JOIN Programacion.ClientesEspeciales on idcadena=cesp_idcadena where activo='S' order by 2"
            If Not especiales Then
                consulta = "select idCadena,Nombre from [" + obj.NombreDB + "].dbo.Cadenas where activo='S' order by 2"
            End If
        Else
            consulta = "select idCadena,Nombre from [" + obj.Servidor + "].[" + obj.NombreDB + "].dbo.Cadenas inner JOIN Programacion.ClientesEspeciales on idcadena=cesp_idcadena where activo='S' order by 2"
            If Not especiales Then
                consulta = "select idCadena,Nombre from [" + obj.Servidor + "].[" + obj.NombreDB + "].dbo.Cadenas where activo='S' order by 2"
            End If
        End If
        
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub Agregar(clieID As Int32, fecha As Date, pares As Int32, linpID As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim SQL As String = ""
        SQL += " INSERT INTO Programacion.EspacioReservado"
        SQL += " (espa_idCadena,espa_fecha,espa_pares,espa_linpID,espa_usuarioCreoID)"
        SQL += " VALUES"
        SQL += " (" & clieID & ",'" & fecha.ToShortDateString & "'," & pares & "," & linpID & "," & Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid & ")"

        operaciones.EjecutaSentencia(SQL)
    End Sub
    Public Sub CambiarFecha(espaID As Int32, Fecha As Date)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update programacion.EspacioReservado set espa_fecha='" & Fecha.ToShortDateString & "' where espa_espaId=" & espaID.ToString
        operaciones.EjecutaSentencia(consulta)
    End Sub
    Public Sub CambiarEstatus(espaID As Int32, Estatus As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update programacion.EspacioReservado set espa_estatus='" & Estatus & "' where espa_espaId=" & espaID.ToString
        operaciones.EjecutaSentencia(consulta)
    End Sub
End Class
