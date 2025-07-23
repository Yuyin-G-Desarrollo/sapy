Imports Persistencia
Imports System.Data.SqlClient

Public Class EmailDA


    Public Sub AltaEmail(ByVal Email As Entidades.Email)

        '@empe_email nchar(100),
        '@empe_personaid int,
        '@empe_clasificacionpersonaid int,
        '@empe_usuariocreoid int

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "empe_email"
        parametro.Value = Email.email
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "empe_personaid"
        parametro.Value = Email.persona.personaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "empe_clasificacionpersonaid"
        parametro.Value = Email.clasificacionpersona.clasificacionpersonaid
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "empe_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_AltaEmailsPersona", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub EditarEmail(ByVal Email As Entidades.Email)

        '@empe_email nchar(100),
        '@empe_personaid int,
        '@empe_clasificacionpersonaid int,
        '@empe_usuariocreoid int

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "empe_email"
        parametro.Value = Email.email
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "empe_personaid"
        parametro.Value = Email.persona.personaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "empe_clasificacionpersonaid"
        parametro.Value = Email.clasificacionpersona.clasificacionpersonaid
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "empe_usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "empe_emailpersonasid"
        parametro.Value = Email.emailpersonasid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_EditarEmailsPersona", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function ListaEmails(ByVal IdPersona As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "select * from Framework.EmailPersonas where empe_personaid =" + IdPersona.ToString
        Return operaciones.EjecutaConsulta(Consulta)
    End Function



End Class
