Imports Nomina.Datos

Public Class ControlAsistenciaBU

    Public Function consultar_RegistroCheck(naveID As Integer, areaID As Integer, PeriodoNomID As Integer, departamentoID As Integer, celulaID As Integer, colaboradorID As Integer, nombreColaborador As String, bandera As Integer) As List(Of Entidades.RegistroCheck)

        Dim objDA As New Nomina.Datos.ControlAsistenciaDA
        Dim tabla As New DataTable

        consultar_RegistroCheck = New List(Of Entidades.RegistroCheck)
        tabla = objDA.buscarRegistrosPeriodo(naveID, areaID, PeriodoNomID, departamentoID, celulaID, colaboradorID, nombreColaborador, bandera)

        Dim filas As Integer = CInt(tabla.Rows.Count)

        For Each fila As DataRow In tabla.Rows

            Dim registroCheck As New Entidades.RegistroCheck
            Dim colaborador As New Entidades.Colaborador
            Dim nave As New Entidades.Naves
            Dim registroExcepcion As New Entidades.RegistroExcepciones
            Dim motivoExcepcion As New Entidades.ExcepcionMotivo

            registroCheck.PId = Integer.Parse(fila("regcheck_id"))

            nave.PNaveId = naveID
            registroCheck.Pregcheck_nave = nave
            If Not IsDBNull(fila("regcheck_normal")) Then
                registroCheck.PCheck_normal = Date.Parse(fila("regcheck_normal"))
            Else
                registroCheck.PCheck_normal = Nothing
            End If

            If Not IsDBNull(fila("regcheck_automatico")) Then
                registroCheck.PCheck_automatico = Date.Parse(fila("regcheck_automatico"))
            Else
                registroCheck.PCheck_automatico = Nothing
            End If


            If Not IsDBNull(fila("regcheck_manual")) Then
                registroCheck.PCheck_manual = Date.Parse(fila("regcheck_manual"))
            Else
                registroCheck.PCheck_manual = Nothing
            End If

            colaborador.PColaboradorid = Integer.Parse(fila("regcheck_colaborador"))
            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            registroCheck.PCheck_Colaborador = colaborador
            registroCheck.PCheck_Resultado = Integer.Parse(fila("regcheck_resultado"))
            registroCheck.PCheck_Tipo = Integer.Parse(fila("regcheck_tipo_check"))

            If Not IsDBNull(fila("regcheck_excepcion_id")) Then
                registroExcepcion.Pregexc_id = Integer.Parse(fila("regcheck_excepcion_id"))
                registroExcepcion.Pregexc_tipo_excepcion = Integer.Parse(fila("regexc_tipo_excepcion"))
                motivoExcepcion.Pexmot_motivo_laboral = CBool(fila("exmot_tipolaboral"))
                registroExcepcion.Pregexc_motivo = motivoExcepcion
                registroCheck.PCheck_Excepcion = registroExcepcion
            Else
                registroExcepcion.Pregexc_id = Nothing
                registroExcepcion.Pregexc_tipo_excepcion = Nothing
                registroCheck.PCheck_Excepcion = registroExcepcion
            End If

            'regcheck_nota

            If Not IsDBNull(fila("regcheck_nota")) Then
                registroCheck.PCheck_Nota = CStr(fila("regcheck_nota"))
            Else
                registroCheck.PCheck_Nota = Nothing
            End If


            consultar_RegistroCheck.Add(registroCheck)

        Next

    End Function

    Public Function tiene_finiquito(colaboradorID As Integer) As Boolean
        Dim objDA As New Datos.ControlAsistenciaDA

        If objDA.tiene_finiquito(colaboradorID).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function ListadoParametroUbicacion(tipo_busqueda As Integer, id_parametros As String) As DataTable
        Dim objbu As New Datos.ControlAsistenciaDA
        Dim tabla As New DataTable
        tabla = objbu.ListadoParametroUbicacion(tipo_busqueda, id_parametros)
        Return tabla
    End Function

    Public Function Resumen_Incidencias(lista_colaboradores As String, fecha_inicio As DateTime, fecha_termino As DateTime) As DataTable
        Dim objbu As New Datos.ControlAsistenciaDA
        Dim tabla As New DataTable
        tabla = objbu.Resumen_Incidencias(lista_colaboradores, fecha_inicio, fecha_termino)
        Return tabla
    End Function

    'Yazmin Rocha (21/04/2016) No colocar "No registro", segun el horario establecido al colaborador
    Public Function buscarHorarioSabado(colaborador As Integer, dia As Integer) As DataTable
        Dim objbu As New Datos.ControlAsistenciaDA
        Dim tabla As New DataTable
        tabla = objbu.buscarHorarioSabado(colaborador, dia)
        Return tabla
    End Function

    ''consultas nuevo control de asistencia
    Public Function cargarConsultaRegistros(ByVal idNave As Int32, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal condiciones As String) As DataTable
        Dim objDa As New Datos.ControlAsistenciaDA
        Dim tabla As New DataTable
        tabla = objDa.cargarConsultaRegistros(idNave, fechaInicio, fechaFin, condiciones)
        Return tabla
    End Function

    Public Function BuscarIncentivosPermisos(ByVal idRegistro As Int32) As DataTable
        Dim objDa As New Datos.ControlAsistenciaDA
        Dim tabla As New DataTable
        tabla = objDa.BuscarIncentivosPermisos(idRegistro)
        Return tabla
    End Function

    Public Function obtenerPuestoColaborador(ByVal idColaborador As Int32) As DataTable
        Dim objDa As New Datos.ControlAsistenciaDA
        Dim tabla As New DataTable
        tabla = objDa.obtenerPuestoColaborador(idColaborador)
        Return tabla
    End Function

    Public Function colaboradorListaAsistencia(ByVal condiciones As String) As DataTable
        Dim objDa As New Datos.ControlAsistenciaDA
        Dim tabla As DataTable
        tabla = objDa.colaboradorListaAsistencia(condiciones)
        Return tabla
    End Function

    Public Function colaboradorExternoListaAsistencia(ByVal idNave As String, PeriodoNomina As Integer) As DataTable
        Dim objDa As New Datos.ControlAsistenciaDA
        Dim tabla As New DataTable
        tabla = objDa.obtenerColaboradorExternoListaAsistencia(idNave, PeriodoNomina)
        Return tabla
    End Function

    Public Function InsertarDatosImportadosXml(ByVal aXmlRegistros As String, ByVal naveID As Integer) As DataTable
        Dim objDa As New Datos.ControlAsistenciaDA
        Dim tabla As New DataTable
        tabla = objDa.InsertarDatosImportadosXml(aXmlRegistros, naveID)
        Return tabla
    End Function

    Public Function InsertarDatosImportadosXmlFormatoNuevo(ByVal aXmlRegistros As String, ByVal naveID As Integer) As DataTable
        Dim objDa As New Datos.ControlAsistenciaDA
        Dim tabla As New DataTable
        tabla = objDa.InsertarDatosImportadosXmlFormatoNuevo(aXmlRegistros, naveID)
        Return tabla
    End Function

    Public Function generaFaltaAsistencia(ByVal registroId As Integer, ByVal periodoId As Integer, ByVal colaboradorId As Integer) As String
        Dim objDA As New Datos.ControlAsistenciaDA
        Dim dtResultado As New DataTable
        Dim mensaje As String = String.Empty

        dtResultado = objDA.generaFaltaAsistencia(registroId, periodoId, colaboradorId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                mensaje = dtResultado.Rows(0)("mensaje").ToString()
            End If
        End If

        Return mensaje
    End Function

    Public Function validaGeneraRegistroNoCheca(ByVal naveId As Integer) As Boolean
        Dim objDA As New Datos.ControlAsistenciaDA
        Dim dtResultado As New DataTable
        Dim resultado As Boolean = False

        dtResultado = objDA.validaGeneraRegistroNoCheca(naveId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = CBool(dtResultado.Rows(0)("resultado").ToString())
            End If
        End If

        Return resultado
    End Function

    Public Function validaCierreAsistenciaNR(ByVal periodoId As Integer) As String
        Dim objDA As New Datos.ControlAsistenciaDA
        Dim dtResultado As New DataTable
        Dim strResutaldo As String = String.Empty

        dtResultado = objDA.validaCierreAsistenciaNR(periodoId)
        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            strResutaldo = dtResultado.Rows(0).Item(0).ToString
        End If

        Return strResutaldo
    End Function

    Public Function ObtieneListaColaboradoresSinIncentivos(ByVal PeriodoID As Integer, ByVal NaveID As Integer) As DataTable
        Dim objDA As New ControlAsistenciaDA
        Dim dtResultado As New DataTable

        dtResultado = objDA.ObtieneListaColaboradoresSinIncentivos(PeriodoID, NaveID)

        Return dtResultado
    End Function

    Public Function ModificaCorteIncentivos(ByVal PeriodoID As Integer, ByVal ColaboradorID As Integer, ByVal CalculoFaltasNuevo As Integer)
        Dim objDA As New ControlAsistenciaDA
        Dim dtResultado As New DataTable

        dtResultado = objDA.ModificaCorteIncentivos(PeriodoID, ColaboradorID, CalculoFaltasNuevo)

        Return dtResultado
    End Function

    Public Function ReplicaRegistros()
        Dim objDA As New ControlAsistenciaDA
        Dim dtResultado As New DataTable

        dtResultado = objDA.ReplicarCoralboradoresChecador()

        Return dtResultado
    End Function

    Public Function ActualizarRegistros(ByVal NaveId As Integer, ByVal fechainicial As Date, ByVal fechafinal As Date)
        Dim objDA As New ControlAsistenciaDA
        Dim dtResultado As New DataTable

        objDA.ActualizarRegistrosChecador(NaveId, fechainicial, fechafinal)

    End Function

End Class
