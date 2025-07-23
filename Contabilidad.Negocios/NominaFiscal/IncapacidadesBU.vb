Imports Entidades

Public Class IncapacidadesBU

    Public Function ValidarIncapacidad(ByVal ColaboradorID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal incapacidadId As Integer) As Entidades.Incapacidades
        Dim ObjDA As New Datos.IncapacidadesDA
        Dim Tabla As New DataTable
        Dim Incapacidad As New Entidades.Incapacidades
        ValidarIncapacidad = New Entidades.Incapacidades

        Tabla = ObjDA.ValidarIncapacidad(ColaboradorID, FechaInicio, FechaFin, incapacidadId)
        If Tabla.Rows.Count > 0 Then
            Incapacidad.PIncapacidadFechaFin = Tabla.Rows(0).Item("inc_fechafin")
            For Each fila As DataRow In Tabla.Rows

                Incapacidad.PValidarIncapacidad = True

                Return Incapacidad
            Next
        End If


    End Function

    Public Function ValidarIncapacidadEditar(ByVal ColaboradorID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal incapacidadID As Integer) As Entidades.Incapacidades
        Dim ObjDA As New Datos.IncapacidadesDA
        Dim Tabla As New DataTable

        ValidarIncapacidadEditar = New Entidades.Incapacidades

        Tabla = ObjDA.ValidarIncapacidadEditar(ColaboradorID, FechaInicio, FechaFin, incapacidadID)

        For Each fila As DataRow In Tabla.Rows
            Dim Incapacidad As New Entidades.Incapacidades
            Incapacidad.PValidarIncapacidad = True
            Return Incapacidad
        Next
    End Function



    Public Function RamoDelSeguro() As DataTable
        Dim objDA As New Datos.IncapacidadesDA
        Return objDA.RamoDelSeguro()
    End Function

    Public Function TipoRiesgo() As DataTable
        Dim objDA As New Datos.IncapacidadesDA
        Return objDA.TipoRiesgo()
    End Function

    Public Function ControlIncapacidad(ByVal idTipoIncapacidad As Int32) As DataTable
        Dim objDA As New Datos.IncapacidadesDA
        Return objDA.ControlIncapacidad(idTipoIncapacidad)
    End Function

    Public Function SecuelaOconsecuencia() As DataTable
        Dim objDA As New Datos.IncapacidadesDA
        Return objDA.SecuelaOconsecuencia()
    End Function

    Public Function TipoMaternidad() As DataTable
        Dim objDA As New Datos.IncapacidadesDA
        Return objDA.TipoMaternidad()
    End Function

    Public Function AltaIncapacidad(ByVal Incapacidad As Entidades.Incapacidades) As DataTable
        Dim ObjDA As New Datos.IncapacidadesDA
        Dim dtGuardar As New DataTable
        dtGuardar = ObjDA.AltaIncapacidad(Incapacidad)
        Return dtGuardar
    End Function

    Public Function ListaIncapacidades(ByVal ColaboradorID As Integer) As List(Of Entidades.Incapacidades)
        Dim ObjDA As New Datos.IncapacidadesDA
        Dim Tabla As New DataTable
        ListaIncapacidades = New List(Of Entidades.Incapacidades)
        Tabla = ObjDA.ListaIncapacidades(ColaboradorID)

        For Each fila As DataRow In Tabla.Rows
            Dim Incapacidad As New Entidades.Incapacidades
            Incapacidad.PIncapacidadFechaInicio = fila("inc_fechainicio")
            Incapacidad.PIncapacidadFechaFin = fila("inc_fechafin")
            ListaIncapacidades.Add(Incapacidad)
        Next
    End Function

    Public Function ListaIncapacidadesReplicadas(ByVal ColaboradorID As Integer) As List(Of Entidades.Incapacidades)
        Dim ObjDA As New Datos.IncapacidadesDA
        Dim Tabla As New DataTable
        ListaIncapacidadesReplicadas = New List(Of Entidades.Incapacidades)
        Tabla = ObjDA.ListaIncapacidadesReplicadas(ColaboradorID)

        For Each fila As DataRow In Tabla.Rows
            Dim Incapacidad As New Entidades.Incapacidades
            Incapacidad.PIncapacidadFechaInicio = fila("inc_fechainicio")
            Incapacidad.PIncapacidadFechaFin = fila("inc_fechafin")
            ListaIncapacidadesReplicadas.Add(Incapacidad)
        Next
    End Function


    Public Function ListaDetalleIncapacidades(ByVal ColaboradorID As Integer, ByVal Fechainicio As DateTime, ByVal FechaFin As DateTime) As List(Of Entidades.Incapacidades)
        Dim ObjDA As New Datos.IncapacidadesDA
        Dim Tabla As New DataTable
        ListaDetalleIncapacidades = New List(Of Entidades.Incapacidades)
        Tabla = ObjDA.ListaDetalleIncapacidades(ColaboradorID, Fechainicio, FechaFin)

        For Each Fila As DataRow In Tabla.Rows
            Dim Incapacidad As New Entidades.Incapacidades
            Incapacidad.PIncapacidadNominpaq = Fila("inc_replicadonominpaq")
            Incapacidad.PIncapacidadID = Fila("inc_incapacidadid")
            Incapacidad.PIncapacidadFolio = Fila("inc_folio")
            Incapacidad.PIncapacidadFechaInicio = Fila("inc_fechainicio")
            Incapacidad.PIncapacidadFechaFin = Fila("inc_fechafin")
            Incapacidad.PIncapacidadDiasAutorizados = Fila("inc_diasautorizados")
            Incapacidad.PRamoSeguroID = Fila("inc_ramoseguroid")
            Incapacidad.PTipoRiesgoID = Fila("inc_tiporiesgoid")
            Incapacidad.PControlIncapacidadID = Fila("inc_controlincapacidadid")
            Incapacidad.PSecuelaID = Fila("inc_secuelaid")
            Incapacidad.PTipoMaternidadID = Fila("inc_tipomaternidadid")
            Incapacidad.PIncapacidadDescripcion = Fila("inc_descripcion")
            Incapacidad.PIncapacidadAnteirorId = Fila("idAnterior")
            Incapacidad.PAceptadoRT = Fila("aceptadort")
            Incapacidad.PEstatusId = Fila("idEstatus")
            ListaDetalleIncapacidades.Add(Incapacidad)
        Next
    End Function

    Public Sub EditarIncapacidades(ByVal Incapacidad As Entidades.Incapacidades)
        Dim ObjDA As New Datos.IncapacidadesDA
        ObjDA.EditarIncapacidades(Incapacidad)
    End Sub

    Public Sub EliminarIncapacidades(ByVal Incapacidad As Entidades.Incapacidades)
        Dim ObjDA As New Datos.IncapacidadesDA
        ObjDA.EliminarIncapacidades(Incapacidad)
    End Sub

    Public Function ListaIncapacidadesFiltro(ByVal NaveID As Integer, ByVal Colaborador As String, ByVal Replicado As String, ByVal patronID As Integer, ByVal fechaInicio As DateTime, ByVal fechafin As DateTime) As List(Of Entidades.Incapacidades)
        Dim ObjDA As New Datos.IncapacidadesDA
        Dim Tabla As New DataTable
        ListaIncapacidadesFiltro = New List(Of Entidades.Incapacidades)
        Tabla = ObjDA.ListaIncapacidadesFiltro(NaveID, Colaborador, Replicado, patronID, fechaInicio, fechafin)

        For Each fila As DataRow In Tabla.Rows
            Dim IncapacidadEnt As New Entidades.Incapacidades
            Dim ColaboradorEnt As New Entidades.Colaborador

            IncapacidadEnt.PIncapacidadID = fila("inc_incapacidadid")
            IncapacidadEnt.PIncapacidadFolio = fila("inc_folio")

            ColaboradorEnt.PNombre = fila("codr_nombre") + " " + fila("codr_apellidopaterno") + " " + fila("codr_apellidomaterno")
            ColaboradorEnt.PColaboradorid = fila("codr_colaboradorID")
            If Not IsDBNull(fila("codr_nominpaqID")) Then
                ColaboradorEnt.PColaboradoridNP = fila("codr_nominpaqID")
            End If

            IncapacidadEnt.PIncapacidadFechaInicio = fila("inc_fechainicio")
            IncapacidadEnt.PIncapacidadFechaFin = fila("inc_fechafin")
            IncapacidadEnt.PIncapacidadDiasAutorizados = fila("inc_diasautorizados")
            IncapacidadEnt.PIncapacidadDescripcion = fila("inc_descripcion")
            IncapacidadEnt.PRamoSeguroDescripcion = fila("ramo_descripcion")
            IncapacidadEnt.PValidaModificacion = fila("validaMov")
            ''Replicacion
            If Not IsDBNull(fila("ramo_NP")) Then
                IncapacidadEnt.PRamoDelSeguroNP = fila("ramo_NP")
            End If

            'If Not IsDBNull(fila("inma_NP")) Then
            '    IncapacidadEnt.PTipoMaternidadNP = fila("inma_NP")
            'End If

            If Not IsDBNull(fila("trin_idNP")) Then
                IncapacidadEnt.PTipoRiesgoNP = fila("trin_idNP")
            End If


            If IsDBNull(fila("trin_descripcion")) Then
                IncapacidadEnt.PTipoRiesgoDescripcion = ""
            Else
                IncapacidadEnt.PTipoRiesgoDescripcion = fila("trin_descripcion")
            End If

            If IsDBNull(fila("inco_descripcion")) Then
                IncapacidadEnt.PControlIncapacidadDescripcion = ""
            Else
                IncapacidadEnt.PControlIncapacidadDescripcion = fila("inco_descripcion")
            End If

            If Not IsDBNull(fila("inco_nominpaqID")) Then
                IncapacidadEnt.PControlIncapacidadIDNP = fila("inco_nominpaqID")
            Else
                'IncapacidadEnt.PControlIncapacidadIDNP = fila("inma_NPID")
            End If

            If IsDBNull(fila("inse_descripcion")) Then
                IncapacidadEnt.PSecuelaDescripcion = ""
            Else
                IncapacidadEnt.PSecuelaDescripcion = fila("inse_descripcion")
            End If

            If Not IsDBNull(fila("inse_nominpaqid")) Then
                IncapacidadEnt.PSecuelaIDNP = fila("inse_nominpaqid")
            End If

            'If IsDBNull(fila("inma_descripcion")) Then
            '    IncapacidadEnt.PTipoMaternidadDescripcion = ""
            'Else
            '    IncapacidadEnt.PTipoMaternidadDescripcion = fila("inma_descripcion")
            'End If

            IncapacidadEnt.PIncapacidadNominpaq = fila("inc_replicadonominpaq")
            IncapacidadEnt.PValidaInicial = fila("inicial")

            IncapacidadEnt.PColaborador = ColaboradorEnt
            ListaIncapacidadesFiltro.Add(IncapacidadEnt)

        Next
    End Function

    Public Function consultaIncapacidadesAnteriores(ByVal idColaborador As Int32, ByVal idIncapacidad As Int32) As DataTable
        Dim objDa As New Datos.IncapacidadesDA
        Dim dtAnt As New DataTable

        dtAnt = objDa.consultaIncapacidadesAnteriores(idColaborador, idIncapacidad)

        If dtAnt.Rows.Count > 0 Then
            Dim dtRow As DataRow = dtAnt.NewRow
            dtRow("idIncapacidad") = 0
            dtRow("descripcion") = ""
            dtAnt.Rows.InsertAt(dtRow, 0)
        End If
        Return dtAnt
    End Function

    Public Function validarPerfilContabilidad() As Boolean
        Dim objDatos As New Datos.IncapacidadesDA
        Dim dtResultado As New DataTable
        Dim resultado As Boolean = False

        dtResultado = objDatos.validarPerfilContabilidad()
        If Not dtResultado Is Nothing Then
            resultado = CBool(dtResultado.Rows(0)("RESULTADO").ToString)
        End If

        Return resultado
    End Function

    Public Function actualizarExpediente(ByVal idColaborador As Int32, ByVal idIncapacidad As Int32, ByVal expedienteid As Int32,
                                         ByVal tituloMovimiento As String,ByVal carpeta As String, ByVal archivo As String) As String
        Dim resul As String = String.Empty
        Dim dtExp As New DataTable
        Dim objDa As New Datos.IncapacidadesDA

        dtExp = objDa.actualizarExpediente(idColaborador, idIncapacidad, expedienteid, tituloMovimiento, carpeta, archivo)

        If dtExp.Rows.Count > 0 Then
            resul = dtExp.Rows(0).Item("resul")
        End If

        Return resul
    End Function

    Public Function consultaListadoArchivos(ByVal idIncapacidad As Int32) As List(Of Entidades.AcusesIncapacidades)
        Dim objDa As New Datos.IncapacidadesDA
        Dim dtInc As New DataTable
        Dim listaArchivos As New List(Of Entidades.AcusesIncapacidades)

        dtInc = objDa.consultaListadoArchivos(idIncapacidad)

        If dtInc.Rows.Count > 0 Then

            For Each rowInc As DataRow In dtInc.Rows
                Dim archivo As New Entidades.AcusesIncapacidades
                archivo.PCarpetaArchivo = rowInc.Item("carpeta")
                archivo.PNombreArchivo = rowInc.Item("nombreArchivo")
                archivo.PRutaArchivo = rowInc.Item("ruta")
                archivo.PTipo = rowInc.Item("tipo")
                archivo.PExpedienteId = rowInc.Item("expedienteId")
                listaArchivos.Add(archivo)
            Next
        End If

        Return listaArchivos
    End Function

    Public Function consultaListadoEstatus(ByVal tipoMovimiento As String) As DataTable
        Dim objDatos As New Datos.IncapacidadesDA
        Dim dtListado As New DataTable

        dtListado = objDatos.consultaListadoEstatus(tipoMovimiento)
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 1 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("ID") = 0
                dtRow("estatus") = ""
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function

    Public Function BuscarColaboradorGeneral(ByVal colaboradorId As Int32) As Entidades.Colaborador
        Dim objColaboradoresDA As New Datos.IncapacidadesDA
        Dim tblColaboradores As New DataTable
        Dim colaborador As New Entidades.Colaborador
        tblColaboradores = objColaboradoresDA.buscarColaboradorGeneral(colaboradorId)
        For Each row As DataRow In tblColaboradores.Rows
            colaborador.PColaboradorid = CStr(row("codr_colaboradorid"))
            colaborador.PNombre = CStr(row("codr_nombre"))
            colaborador.PApaterno = CStr(row("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(row("codr_apellidomaterno"))
            colaborador.pCurp = CStr(row("codr_curp"))
            colaborador.PRfc = CStr(row("codr_rfc"))
            colaborador.PEstadoCivil = CStr(row("codr_estadocivil"))
            colaborador.PCalle = CStr(row("codr_domiciliocalle"))
            colaborador.Pnumero = CStr(row("codr_domicilionumero"))
            colaborador.Pcolonia = CStr(row("codr_domiciliocolonia"))
            Try

                colaborador.pIdAnual = CInt(row("codr_idanual"))
            Catch ex As Exception

            End Try

            If Not IsDBNull(row("codr_activo")) Then
                colaborador.PActivo = CBool(row("codr_activo"))
            Else
                colaborador.PActivo = False
            End If

            If Not IsDBNull(row("codr_cp")) Then
                colaborador.PCP = CStr(row("codr_cp"))
            Else
                colaborador.PCP = ""
            End If

            colaborador.PEstadoCivil = CStr(row("codr_estadocivil"))
            colaborador.PFechaNacimiento = CDate(row("codr_fechanacimiento"))

            If Not IsDBNull(row("codr_telefonocasa")) Then
                colaborador.PTelefonoCasa = CStr(row("codr_telefonocasa"))
            End If
            If Not IsDBNull(row("codr_sexo")) Then
                colaborador.PSexo = CStr(row("codr_sexo"))
            End If
            If Not IsDBNull(row("codr_claveelector")) Then
                colaborador.PClaveElector = CStr(row("codr_claveelector"))
            End If

            If Not IsDBNull(row("codr_telefonocelular")) Then
                colaborador.PTelefonoCel = CStr(row("codr_telefonocelular"))
            End If
            If Not IsDBNull(row("codr_email")) Then
                colaborador.PEmail = CStr(row("codr_email"))
            End If

            Dim ciudad As New Ciudades
            ciudad.CciudadId = CInt(row("codr_ciudadid"))
            ciudad.CNombre = CStr(row("city_nombre"))

            colaborador.PCiudad = ciudad

        Next
        Return colaborador
    End Function

    Public Function buscarInformacionLaboral(ByVal colaboradorId As Int32) As Entidades.ColaboradorLaboral

        Dim objDA As New Datos.IncapacidadesDA
        Dim tabla As New DataTable

        Dim laboral As New Entidades.ColaboradorLaboral
        tabla = objDA.buscarInformacionLaboral(colaboradorId)
        For Each row As DataRow In tabla.Rows
            Dim colaborador As New Entidades.Colaborador

            laboral.PColaboradorLaboralId = CInt(row("labo_colaboradorlaboralid"))
            colaborador.PColaboradorid = CInt(row("labo_colaboradorid"))
            laboral.PColaboradorId = colaborador
            If Not IsDBNull(row("labo_naveid")) Then
                Dim nave As New Entidades.Naves
                nave.PNaveId = CInt(row("nave_naveid"))
                nave.PNombre = CStr(row("nave_nombre"))
                laboral.PNaveId = nave
            End If
            If Not IsDBNull(row("labo_telefono")) Then
                laboral.telefono = row("labo_telefono")
            End If
            If Not IsDBNull(row("labo_ext")) Then
                laboral.extencion = row("labo_ext")
            End If
            If Not IsDBNull(row("labo_email")) Then
                laboral.emailLaboral = row("labo_email")
            End If
            If Not IsDBNull(row("labo_jefeInmediato")) Then
                laboral.jefeInmediato = row("labo_jefeInmediato")
            End If
            If Not IsDBNull(row("labo_jefeid")) Then
                laboral.jefeInmediatoid = row("labo_jefeid")
            End If
            Try
                laboral.PGeneraHorasExtras = CBool(row("labo_generahorasextras"))
            Catch ex As Exception

            End Try
            Try
                laboral.PNIP = CInt(row("labo_nip"))
            Catch ex As Exception

            End Try



            If Not IsDBNull(row("labo_departamentoid")) Then
                Dim departamento As New Entidades.Departamentos
                departamento.Ddepartamentoid = CInt(row("grup_grupoid"))
                departamento.DNombre = CStr(row("grup_name"))
                If Not IsDBNull(row("grup_nominpaqid")) Then
                    departamento.PDepartamentoIDNP = CStr(row("grup_nominpaqid"))
                Else
                    departamento.PDepartamentoIDNP = 0
                End If
                laboral.PDepartamentoId = departamento

            End If

            If Not IsDBNull(row("labo_puestoid")) Then
                Dim puestos As New Entidades.Puestos
                puestos.Ppuestosid = CInt(row("pues_puestoid"))
                puestos.PNombre = CStr(row("pues_nombre"))
                If Not IsDBNull(row("pues_nominpaqid")) Then
                    puestos.PPuestoIDNP = row("pues_nominpaqid")
                End If

                laboral.PPuestoId = puestos
            End If

            If Not IsDBNull(row("labo_celulaid")) Then
                Dim celula As New Entidades.Celulas
                celula.PCelulaid = CInt(row("labo_celulaid"))
                celula.PNombre = CStr(row("celu_nombre"))
                laboral.PCelula = celula
            End If

            If Not IsDBNull(row("labo_horarioid")) Then
                Dim horario As New Entidades.Horarios
                horario.DHorariosid = CInt(row("labo_horarioid"))
                horario.DNombre = CStr(row("hora_nombre"))
                horario.DRetardo = CInt(row("hora_retardo"))
                laboral.PHorarioId = horario
            End If
            If Not IsDBNull(row("labo_horario2id")) Then
                Dim horario As New Entidades.Horarios
                horario.DHorariosid = CInt(row("labo_horario2id"))
                horario.DNombre = CStr(row("hora_nombre"))
                horario.DRetardo = CInt(row("hora_retardo"))
                laboral.PHorario2Id = horario
            End If
            Try
                laboral.PAreaID = (row("labo_areaid"))
            Catch ex As Exception

            End Try
            Try
                laboral.PReporte = (row("labo_reportes"))
            Catch ex As Exception

            End Try
            Try
                laboral.PGanaIncentivos = (row("labo_ganaincentivos"))
            Catch ex As Exception

            End Try

            Try
                laboral.PCheca = (row("labo_checa"))
            Catch ex As Exception

            End Try

        Next
        Return laboral
    End Function

    Public Function CredencialColaborador(ByVal Colaborador As Int32) As Entidades.ColaboradorExpediente
        Dim objDA As New Datos.IncapacidadesDA
        Dim tablaArchivos As New DataTable
        CredencialColaborador = New Entidades.ColaboradorExpediente
        tablaArchivos = objDA.BuscarCredencialColaborador(Colaborador)
        For Each row As DataRow In tablaArchivos.Rows
            Dim objArchivo As New Entidades.ColaboradorExpediente

            objArchivo.PCarpeta = CStr(row("cexp_carpeta"))
            objArchivo.PNombreArchivo = CStr(row("cexp_nombrearchivo"))
            Return objArchivo
        Next

    End Function

    Public Function validaIncapacidadIncial(ByVal colaboradorId As Int32, ByVal incapacidaId As Int32) As Int32
        Dim objDA As New Datos.IncapacidadesDA
        Dim tabla As New DataTable
        Dim resul As Int32 = 0

        tabla = objDA.validaIncapacidadIncial(colaboradorId, incapacidaId)

        If tabla.Rows.Count > 0 Then
            resul = tabla.Rows(0).Item("existeInicial")
        End If

        Return resul
    End Function

End Class
