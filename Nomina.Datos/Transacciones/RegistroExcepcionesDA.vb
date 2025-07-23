Imports Persistencia
Imports System.Data.SqlClient

Public Class RegistroExcepcionesDA

    Public Function buscarRegistrosExcepcionesPeriodo(ByVal naveID As Integer, ByVal PeriodoNomID As Integer, ByVal departamentoID As Integer, ByVal colaboradorID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "PeriodoNomID"
        parametro.Value = PeriodoNomID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "registroExcepcion"
        parametro.Value = 0
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveID"
        parametro.Value = naveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "departamentoID"
        parametro.Value = departamentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorID"
        parametro.Value = colaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "permisoDepartamental"
        parametro.Value = 0
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("ControlAsistencia.SP_Consulta_Registro_Excepcion", listaParametros)

    End Function


    Public Function buscarRegistroExcepcion(ByVal naveID As Integer, ByVal departamentoID As Integer, ByVal colaboradorID As Integer, ByVal registroExcepcion As Integer, ByVal permisoDepartamental As Boolean) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "PeriodoNomID"
        parametro.Value = 0
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "registroExcepcion"
        parametro.Value = registroExcepcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveID"
        parametro.Value = naveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "departamentoID"
        parametro.Value = departamentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorID"
        parametro.Value = colaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "permisoDepartamental"
        parametro.Value = permisoDepartamental
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("ControlAsistencia.SP_Consulta_Registro_Excepcion", listaParametros)

    End Function


    Public Sub guardar_RegistroExcepcion(ByVal registroExcepcion As Entidades.RegistroExcepciones, _
                                         ByVal regCheck As Entidades.RegistroCheck, ByVal checkAutomatico As DateTime, ByVal bandera As Integer, ByVal velador As Boolean)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@regexc_fecha_inicio AS DATE, 
        '@regexc_fecha_termino AS DATE, 
        '@regexc_hora_inicio AS DATETIME, 
        '@regexc_hora_termino AS DATETIME, 
        '@regexc_usuario_sol  AS INTEGER, 
        '@regexc_usuario_rev AS INTEGER, 
        '@regexc_solicitud_fecha AS DATE, 
        '@regexc_revision_fecha AS DATE, 
        '@regexc_motivo_nota AS VARCHAR, 
        '@regexc_puntualidad_asistencia AS BIT, 
        '@regexc_caja_ahorro AS BIT, 
        '@regexc_tipo_excepcion AS INTEGER, 
        '@regexc_motivo_id AS INTEGER, 
        '@regexc_estado_excepcion AS INTEGER, 
        '@regexc_colaborador_id AS INTEGER, 
        '@regexc_departamento_id AS INTEGER
        '@checkID AS INTEGER,
        '@check_automatico AS DATETIME,
        '@bandera AS INTEGER

        Dim parametro As New SqlParameter
        parametro.ParameterName = "regexc_fecha_inicio"
        parametro.Value = registroExcepcion.Pregexc_fecha_inicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_fecha_termino"
        parametro.Value = registroExcepcion.Pregexc_fecha_termino
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_hora_inicio"
        If velador Then
            parametro.Value = registroExcepcion.Pregexc_hora_termino
        Else
            parametro.Value = registroExcepcion.Pregexc_hora_inicio
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_hora_termino"
        If velador Then
            parametro.Value = registroExcepcion.Pregexc_hora_inicio
        Else
            parametro.Value = registroExcepcion.Pregexc_hora_termino
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_usuario_sol"
        Try
            parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            listaParametros.Add(parametro)
        Catch ex As Exception
            parametro.Value = 0
            listaParametros.Add(parametro)
        End Try

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_motivo_nota"
        parametro.Value = registroExcepcion.Pregexc_motivo_nota
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_puntualidad_asistencia"
        parametro.Value = registroExcepcion.Pregexc_puntualidad_asistencia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_caja_ahorro"
        parametro.Value = registroExcepcion.Pregexc_caja_ahorro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_tipo_excepcion"
        parametro.Value = registroExcepcion.Pregexc_tipo_excepcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_motivo_id"
        parametro.Value = registroExcepcion.Pregexc_motivo.Pexmot_id
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_estado_excepcion"
        parametro.Value = registroExcepcion.Pregexc_estado_excepcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_colaborador_id"
        parametro.Value = registroExcepcion.Pregexc_colaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_departamento_id"
        parametro.Value = registroExcepcion.Pregexc_departamento.Ddepartamentoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "checkID"
        If IsNothing(regCheck) Then
            parametro.Value = 0
        Else
            parametro.Value = regCheck.PId
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveid"
        If IsNothing(regCheck) Then
            parametro.Value = 0
        Else
            parametro.Value = regCheck.Pregcheck_nave.PNaveId
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "check_automatico"
        parametro.Value = Date.Parse(checkAutomatico)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipo"
        parametro.Value = regCheck.PCheck_Tipo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipos"
        parametro.Value = regCheck.PRegcheck_Tipos
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("ControlAsistencia.SP_Alta_Registro_Excepcion", listaParametros)
        Console.WriteLine("Mandó la sentencia")

    End Sub


    Public Sub aprobar_RegistroExcepcion(ByVal regexc_id As Integer, ByVal colaboradorID As Integer, ByVal horario_id As Integer, ByVal naveID As Integer, _
                                         ByVal bandera As Integer, ByVal PyA As Boolean, ByVal CdA As Boolean)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@regexc_id as INTEGER,      	        
        '@colaboradorID AS INTEGER,
        '@horario_id AS INTEGER,
        '@regexc_usuario_rev AS INTEGER,
        '@naveID AS INTEGER,
        '@bandera AS INTEGER 
        'DECLARE @fecha_inicio DATE
        'DECLARE @fecha_termino DATE 
        'DECLARE @fecha DATE
        'DECLARE @hora_inicio TIME 
        'DECLARE @hora_fin TIME 
        'DECLARE @tipo_check INTEGER
        'DECLARE @hora_check DATETIME  


        Dim parametro As New SqlParameter
        parametro.ParameterName = "regexc_id"
        parametro.Value = regexc_id
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorID"
        parametro.Value = colaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "horario_id"
        parametro.Value = horario_id
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_usuario_rev"
        Try
            parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            listaParametros.Add(parametro)
        Catch ex As Exception
            parametro.Value = 0
            listaParametros.Add(parametro)
        End Try

        parametro = New SqlParameter
        parametro.ParameterName = "naveID"
        parametro.Value = naveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "bandera"
        'parametro.Value = bandera
        'listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_puntualidad_asistencia"
        parametro.Value = PyA
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regexc_caja_ahorro"
        parametro.Value = CdA
        listaParametros.Add(parametro)


        operaciones.EjecutarSentenciaSP("ControlAsistencia.SP_Aprobacion_Excepcion_Horario", listaParametros)
        Console.WriteLine("Mandó la sentencia")

    End Sub

    Public Function buscar_horarioID(ByVal colaboradorID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT labo_horarioid FROM Nomina.ColaboradorLaboral WHERE ColaboradorLaboral.labo_colaboradorid = " + colaboradorID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function detalleRegistro_Excepcion(ByVal regexc_id As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM ControlAsistencia.RegistroExcepcion WHERE regexc_id = " + regexc_id.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function


End Class
