Imports System.Data.SqlClient


Public Class ColaboradorAcademicoDA


    Public Sub AgregarInformacionAcademica(ByVal Academica As Entidades.AcademicosColaborador, ByVal Colaboradorid As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Listaparametos As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "coac_colaboradorid"
        parametro.Value = Colaboradorid
        Listaparametos.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "coac_escuela"
        parametro.Value = Academica.PNombreEscuela
        Listaparametos.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coac_inicio"
        parametro.Value = Academica.PAnioInicio
        Listaparametos.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coac_fin"

        If Academica.PAnioTermino = 0 Then
            parametro.Value = DBNull.Value

        Else
            parametro.Value = Academica.PAnioTermino
        End If


        Listaparametos.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coac_estado"
        parametro.Value = Academica.PEstado
        Listaparametos.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coac_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Listaparametos.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coac_carrera"
        parametro.Value = Academica.PCarrera
        Listaparametos.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coac_grado"
        parametro.Value = Academica.PGrado
        Listaparametos.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Agregar_INF_Academica", Listaparametos)



    End Sub




    Public Sub EditarInformacionAcademica(ByVal Academica As Entidades.AcademicosColaborador, ByVal IdAcademica As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Listaparametos As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "coac_academicaid"
        parametro.Value = IdAcademica
        Listaparametos.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "coac_escuela"
        parametro.Value = Academica.PNombreEscuela
        Listaparametos.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coac_inicio"
        parametro.Value = Academica.PAnioInicio
        Listaparametos.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coac_fin"
        parametro.Value = Academica.PAnioTermino
        Listaparametos.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coac_estado"
        parametro.Value = Academica.PEstado
        Listaparametos.Add(parametro)

   

        parametro = New SqlParameter
        parametro.ParameterName = "coac_carrera"
        parametro.Value = Academica.PCarrera
        Listaparametos.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coac_grado"
        parametro.Value = Academica.PGrado
        Listaparametos.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Editar_INF_Academica", Listaparametos)



    End Sub




    Public Sub EliminarInformacionAcademica(ByVal aca As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Listaparametos As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "academicaid"
        parametro.Value = aca
        Listaparametos.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_EliminarInfoAcademica", Listaparametos)

    End Sub

    Public Function listaColaboradorAcademica(ByVal colaboradorId As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.ColaboradorAcademica where coac_colaboradorid=" + colaboradorId.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function



End Class
