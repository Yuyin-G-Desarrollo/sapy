Public Class ArchivosDA

    Public Sub EnviarArchivos(ByVal Archivos As Entidades.ColaboradorExpediente, ByVal ColaboradorId As Int32, ByVal Archivo As String)
        Dim operacionesProcedimientos As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "cexp_colaboradorid"
        parametro.Value = ColaboradorId
        listaparametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "cexp_carpeta"
        parametro.Value = Archivos.PCarpeta
        listaparametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "cexp_nombrearchivo"
        parametro.Value = Archivo
        listaparametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "cexp_titulo"
        parametro.Value = Archivos.Ptitulo
        listaparametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "cexp_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "cexp_credencial"
        parametro.Value = Archivos.PCredencial
        listaparametros.Add(parametro)

        operacionesProcedimientos.EjecutarConsultaSP("Nomina.SP_EnvioArchivos", listaparametros)

    End Sub

    Public Sub EliminarArchivoColaborador(ByVal Archivoid As Int32)
        Dim operacionesProcedimientos As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "archivoid"
        parametro.Value = Archivoid
        listaparametros.Add(parametro)

        operacionesProcedimientos.EjecutarConsultaSP("Nomina.SP_eliminar_colaboradorarchivo", listaparametros)
    End Sub

    Public Function BuscarArchivosColaborador(ByVal Colaborador As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.ColaboradorExpediente where cexp_colaboradorid =" + Colaborador.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscarCredencialColaborador(ByVal Colaborador As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.ColaboradorExpediente where cexp_colaboradorid=" + Colaborador.ToString
        consulta += " and cexp_credencial=1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

End Class
