Public Class ColaboradorReferenciasDA
    Public Function listaColaboradorReferencias(ByVal colaboradorId As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Nomina.ColaboradorReferencias where cref_colaboradorid=" + colaboradorId.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Sub AgregarColaboradorReferencias(ByVal referencias As Entidades.ColaboradorReferencias)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New List(Of SqlClient.SqlParameter)
        Dim param As New SqlClient.SqlParameter

        param.ParameterName = "colaboradorid"
        param.Value = referencias.PColaboradorId.PColaboradorid
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "parentezco"
        param.Value = referencias.PParentezco
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "nombre"
        param.Value = referencias.PNombre
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "ocupacion"
        param.Value = referencias.POcupacion
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "telefono"
        param.Value = referencias.PTelefono
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "usuariocreo"
        param.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        parametros.Add(param)
        'comentado no se captura fecha de nacimiento
        'param = New SqlClient.SqlParameter
        'param.ParameterName = "fechaNacimiento"
        'param.Value = referencias.PFechaNacimiento
        'parametros.Add(param)


        objPersistencia.EjecutarSentenciaSP("Nomina.SP_altas_colaboradorreferencias", parametros)

    End Sub



    Public Sub EditarColaboradorReferencias(ByVal idreferencia As Int32, ByVal referencias As Entidades.ColaboradorReferencias)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New List(Of SqlClient.SqlParameter)
        Dim param As New SqlClient.SqlParameter

        param.ParameterName = "Referenciaid"
        param.Value = idreferencia
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "parentezco"
        param.Value = referencias.PParentezco
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "nombre"
        param.Value = referencias.PNombre
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "ocupacion"
        param.Value = referencias.POcupacion
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "telefono"
        param.Value = referencias.PTelefono
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "usuariomodifico"
        param.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        parametros.Add(param)
        'ya no se captura fecha de nacimiento
        'param = New SqlClient.SqlParameter
        'param.ParameterName = "fechaNacimiento"
        'param.Value = referencias.PFechaNacimiento
        'parametros.Add(param)

    

        objPersistencia.EjecutarSentenciaSP("Nomina.SP_Editar_colaboradorreferencias", parametros)

    End Sub





    Public Sub EliminarColaboradorReferencia(ByVal referenciaId As Int32)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New List(Of SqlClient.SqlParameter)
        Dim param As New SqlClient.SqlParameter

        param.ParameterName = "id"
        param.Value = referenciaId
        parametros.Add(param)

        objPersistencia.EjecutarSentenciaSP("Nomina.SP_eliminar_colaboradorreferencias", parametros)
    End Sub
End Class
