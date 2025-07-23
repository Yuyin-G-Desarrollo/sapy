Imports Persistencia
Imports System.Data.SqlClient

Public Class TelefonoDA



    Public Sub AltaTelefono(ByVal Telefono As Entidades.Telefono)

        ' @clasificacionpersonaid AS INTEGER
        ',@personaid AS INTEGER
        ',@telefono AS VARCHAR(50)
        ',@extension AS VARCHAR(50)
        ',@tipotelefonoid AS INTEGER
        ',@usuariocreoid AS INTEGER

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        parametro.Value = Telefono.clasificacionpersona.clasificacionpersonaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "personaid"
        parametro.Value = Telefono.persona.personaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "telefono"
        parametro.Value = Telefono.telefono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "extension"
        parametro.Value = Telefono.extension
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipotelefonoid"
        parametro.Value = Telefono.tipotelefono.tipotelefonoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Alta_Telefono", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub


    Public Sub EditarTelefono(ByVal Telefono As Entidades.Telefono)

        ' @clasificacionpersonaid AS INTEGER
        ',@personaid AS INTEGER
        ',@telefono AS VARCHAR(50)
        ',@extension AS VARCHAR(50)
        ',@tipotelefonoid AS INTEGER
        ',@usuariocreoid AS INTEGER

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
  

        parametro = New SqlParameter
        parametro.ParameterName = "personaid"
        parametro.Value = Telefono.persona.personaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "telefonoid"
        parametro.Value = Telefono.telefonoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "telefono"
        parametro.Value = Telefono.telefono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "extension"
        parametro.Value = Telefono.extension
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipotelefonoid"
        parametro.Value = Telefono.tipotelefono.tipotelefonoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = Telefono.activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Editar_TelefonoPersona", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub


    Public Function ListaTelefonos(ByVal idPersona As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "select * from Framework.Telefono as a left join Framework.TipoTelefono as b on (a.tele_tipotelefonoid = b.tite_tipotelefonoid) where tele_personaid = " + idPersona.ToString
        Return operaciones.EjecutaConsulta(Consulta)
    End Function



End Class
