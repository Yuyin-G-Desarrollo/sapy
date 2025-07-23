Imports Entidades
Imports Nomina.Datos

Public Class ColaboradoresBU
    Public Function listaColaboradores(ByVal Nombre As String, ByVal Curp As String, ByVal Rfc As String, ByVal activo As Boolean) As List(Of Entidades.Colaborador)
        Dim objColaboradoresDA As New Datos.ColaboradoresDA
        Dim tblColaboradores As New DataTable
        listaColaboradores = New List(Of Entidades.Colaborador)
        tblColaboradores = objColaboradoresDA.listaColaboradores(Nombre, Curp, Rfc, activo)
        For Each row As DataRow In tblColaboradores.Rows
            Dim colaborador As New Entidades.Colaborador
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
            If Not IsDBNull(row("codr_telefonocasa")) Then
                colaborador.PTelefonoCasa = CStr(row("codr_telefonocasa"))
            End If
            colaborador.PTelefonoCel = CStr(row("codr_telefonocelular"))
            listaColaboradores.Add(colaborador)
        Next
        Return listaColaboradores
    End Function

    Public Function listaColaboradoresNave(ByVal NaveId As Int32) As DataTable
        Dim objColaboradoresDA As New Datos.ColaboradoresDA
        Dim tblColaboradores As New DataTable
        tblColaboradores = objColaboradoresDA.listaColaboradoresNave(NaveId)
        Return tblColaboradores
    End Function

    Public Function listaColaboradoresDepto(ByVal DeptoId As Int32) As DataTable
        Dim objColaboradoresDA As New Datos.ColaboradoresDA
        Dim tblColaboradores As New DataTable
        tblColaboradores = objColaboradoresDA.listaColaboradoresDepto(DeptoId)
        Return tblColaboradores
    End Function

    Public Function listaColaboradoresCelula(ByVal celulaID As Integer) As DataTable
        Dim objColaboradoresDA As New Datos.ColaboradoresDA
        Dim tblColaboradores As New DataTable
        tblColaboradores = objColaboradoresDA.listaColaboradoresCelula(celulaID)
        Return tblColaboradores
    End Function

    Public Function BuscarEmpleado(ByVal nombre As String, ByVal IDUSUARIO As Int32, ByVal naveid As Int32) As List(Of Entidades.Colaborador)
        Dim objColaboradorDA As New Datos.ColaboradoresDA
        Dim tablaColaboradores As New DataTable
        BuscarEmpleado = New List(Of Entidades.Colaborador)
        tablaColaboradores = objColaboradorDA.ListaEmpleados(nombre, IDUSUARIO, naveid)
        For Each row As DataRow In tablaColaboradores.Rows
            Dim colaborador As New Entidades.Colaborador
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
            colaborador.PFechaCreacion = CStr(row("codr_fechacreacion"))


            If Not IsDBNull(row("codr_telefonocasa")) Then
                colaborador.PTelefonoCasa = CStr(row("codr_telefonocasa"))
            End If
            colaborador.PTelefonoCel = CStr(row("codr_telefonocelular"))
            Dim Departamento As New Entidades.Departamentos
            If Not IsDBNull(row("grup_name")) Then
                Departamento.DNombre = CStr(row("grup_name"))
                Departamento.Ddepartamentoid = CStr(row("grup_grupoid"))
            End If
            Dim vCelulas As New Entidades.Celulas
            If Not IsDBNull(row("celu_celulaid")) Then
                vCelulas.PCelulaid = CStr(row("celu_celulaid"))
                vCelulas.PNombre = CStr(row("celu_nombre"))
            End If
            

            colaborador.PIDepartamento = Departamento
            colaborador.Pcelulas = vCelulas
            colaborador.PEmail = CStr(row("real_tipo"))
            BuscarEmpleado.Add(colaborador)

        Next
        Return BuscarEmpleado


    End Function

    Public Function BuscarEmpleadoSegunDepartamentoTabla(ByVal nombre As String, ByVal IDUSUARIO As Int32, ByVal Naveid As Int32, ByVal periodo As Int32) As DataTable
        Dim objColaboradorDA As New Datos.ColaboradoresDA
        Return objColaboradorDA.ListaEmpleadosSegunDepartamentoUsuarioConsulta(nombre, IDUSUARIO, Naveid, periodo)
    End Function

    Public Function BuscarEmpleadoSegunDepartamento(ByVal nombre As String, ByVal IDUSUARIO As Int32, ByVal Naveid As Int32) As List(Of Entidades.Colaborador)
        Dim objColaboradorDA As New Datos.ColaboradoresDA
        Dim tablaColaboradores As New DataTable
        BuscarEmpleadoSegunDepartamento = New List(Of Entidades.Colaborador)
        tablaColaboradores = objColaboradorDA.ListaEmpleadosSegunDepartamentoUsuario(nombre, IDUSUARIO, Naveid)
        Try

            For Each row As DataRow In tablaColaboradores.Rows
                Dim colaborador As New Entidades.Colaborador
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
                colaborador.PFechaCreacion = CStr(row("codr_fechacreacion"))


                If Not IsDBNull(row("codr_telefonocasa")) Then
                    colaborador.PTelefonoCasa = CStr(row("codr_telefonocasa"))
                End If
                colaborador.PTelefonoCel = CStr(row("codr_telefonocelular"))
                Dim Departamento As New Entidades.Departamentos
                If Not IsDBNull(row("grup_name")) Then
                    Departamento.DNombre = CStr(row("grup_name"))
                    Departamento.Ddepartamentoid = CStr(row("grup_grupoid"))
                End If

                Dim celulas As New Entidades.Celulas
                If Not IsDBNull(row("celu_nombre")) Then
                    celulas.PNombre = row("celu_nombre")
                End If


                colaborador.Pcelulas = celulas
                colaborador.PIDepartamento = Departamento
                BuscarEmpleadoSegunDepartamento.Add(colaborador)

            Next
        Catch ex As Exception

        End Try
        Return BuscarEmpleadoSegunDepartamento


    End Function



    Public Sub AgregarColaborador(ByVal colaborador As Entidades.Colaborador)
        Dim objColaboradorDA As New ColaboradoresDA
        objColaboradorDA.AgregarColaborador(colaborador)
    End Sub

    Public Sub EditarColaborador(ByVal colaborador As Entidades.Colaborador, ByVal IdColaborador As Int32)
        Dim objColaboradorDA As New ColaboradoresDA
        objColaboradorDA.EditarColaborador(colaborador, IdColaborador)
    End Sub

    Public Function BuscarColaboradorId() As Int32
        BuscarColaboradorId = 0
        Dim objColaboradorDA As New ColaboradoresDA
        Dim tableCol As New DataTable
        tableCol = objColaboradorDA.buscarColaboradorId
        For Each fila As DataRow In tableCol.Rows
            BuscarColaboradorId = CInt(fila(0))
        Next
        Return BuscarColaboradorId
    End Function

    Public Function BuscarColaboradorGeneral(ByVal colaboradorId As Int32) As Entidades.Colaborador
        Dim objColaboradoresDA As New Datos.ColaboradoresDA
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

            If Not IsDBNull(row("codr_entrecalles")) Then
                colaborador.PEntreCalles = CStr(row("codr_entrecalles"))
            End If

            If Not IsDBNull(row("codr_domicilioreferencia")) Then
                colaborador.PReferencia = CStr(row("codr_domicilioreferencia"))
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


    'Public Function ListaColaboradoresFiltroCompleto(ByVal Nombre As String, ByVal Curp As String, ByVal RFC As String _
    '                                                 , ByVal activo As Boolean, ByVal idNave As Int32, ByVal idDepartamento As Int32, _
    '                                                 ByVal puesto As Int32, ByVal externo As Boolean) As List(Of Entidades.Colaborador)
    '    Dim objDA As New Datos.ColaboradoresDA
    '    Dim tblColaboradores As New DataTable
    '    ListaColaboradoresFiltroCompleto = New List(Of Entidades.Colaborador)
    '    tblColaboradores = objDA.listaColaboradoresFiltroCompleto(Nombre, Curp, RFC, activo, idNave, idDepartamento, puesto, externo)
    '    For Each row As DataRow In tblColaboradores.Rows
    '        Dim colaborador As New Entidades.Colaborador
    '        colaborador.PColaboradorid = CStr(row("codr_colaboradorid"))
    '        colaborador.PNombre = CStr(row("codr_nombre"))
    '        colaborador.PApaterno = CStr(row("codr_apellidopaterno"))
    '        colaborador.PAmaterno = CStr(row("codr_apellidomaterno"))
    '        colaborador.pCurp = CStr(row("codr_curp"))
    '        colaborador.PRfc = CStr(row("codr_rfc"))
    '        colaborador.PEstadoCivil = CStr(row("codr_estadocivil"))
    '        colaborador.PCalle = CStr(row("codr_domiciliocalle"))
    '        colaborador.Pnumero = CStr(row("codr_domicilionumero"))
    '        colaborador.Pcolonia = CStr(row("codr_domiciliocolonia"))
    '        colaborador.PNaveID = CInt(row("labo_naveid"))
    '        colaborador.PFechaCreacion = row("real_fecha")
    '        If Not IsDBNull(row("codr_telefonocasa")) Then
    '            colaborador.PTelefonoCasa = CStr(row("codr_telefonocasa"))
    '        End If
    '        colaborador.PTelefonoCel = CStr(row("codr_telefonocelular"))
    '        ListaColaboradoresFiltroCompleto.Add(colaborador)
    '    Next

    '    Return ListaColaboradoresFiltroCompleto
    'End Function

    Public Function ListaColaboradoresFiltroCompleto(ByVal Filtros As Entidades.FiltrosFichaColaborador) As DataTable
        Dim objDA As New Datos.ColaboradoresDA
        Return objDA.listaColaboradoresFiltroCompleto(Filtros)
    End Function

    Public Function ListaColaboradoresFiltroCompletoGeneranHorasExtras(ByVal Nombre As String, ByVal Curp As String, ByVal RFC As String _
                                                    , ByVal activo As Boolean, ByVal idNave As Int32, ByVal idDepartamento As Int32, _
                                                    ByVal puesto As Int32) As List(Of Entidades.Colaborador)
        Dim objDA As New Datos.ColaboradoresDA
        Dim tblColaboradores As New DataTable
        ListaColaboradoresFiltroCompletoGeneranHorasExtras = New List(Of Entidades.Colaborador)
        tblColaboradores = objDA.listaColaboradoresFiltroCompletoGeneranHorasExtras(Nombre, Curp, RFC, activo, idNave, idDepartamento, puesto)
        For Each row As DataRow In tblColaboradores.Rows
            Dim colaborador As New Entidades.Colaborador
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
            If Not IsDBNull(row("codr_telefonocasa")) Then
                colaborador.PTelefonoCasa = CStr(row("codr_telefonocasa"))
            End If
            colaborador.PTelefonoCel = CStr(row("codr_telefonocelular"))
            ListaColaboradoresFiltroCompletoGeneranHorasExtras.Add(colaborador)
        Next

        Return ListaColaboradoresFiltroCompletoGeneranHorasExtras
    End Function


    Public Function ValidarCurp(ByVal Curp As String) As String
        Dim objDA As New ColaboradoresDA
        ValidarCurp = ""
        Dim tablaCurp As DataTable
        tablaCurp = objDA.buscarColaboradorPorCURP(Curp)
        If (tablaCurp.Rows.Count > 0) Then
            ValidarCurp = "Ya existe un registro con este mismo numero de CURP"
        Else
            ValidarCurp = ""
        End If
    End Function





    Public Function ListaColaboradoresFiltroCompletoCURP(ByVal Nombre As String, ByVal Curp As String, ByVal RFC As String _
                                                     , ByVal idNave As Int32, ByVal idDepartamento As Int32, _
                                                     ByVal puesto As Int32) As List(Of Entidades.Colaborador)
        Dim objDA As New Datos.ColaboradoresDA
        Dim tblColaboradores As New DataTable
        ListaColaboradoresFiltroCompletoCURP = New List(Of Entidades.Colaborador)
        tblColaboradores = objDA.listaColaboradoresFiltroCompletoCURP("", Curp, "", 0, 0, 0)
        For Each row As DataRow In tblColaboradores.Rows
            Dim colaborador As New Entidades.Colaborador
            Dim Finiquitos As New Entidades.Finiquitos
            Dim MotivoFiniquito As New Entidades.MotivosFiniquito
            Try
                MotivoFiniquito.PNombre = CStr(row("mfin_nombre"))
            Catch ex As Exception

            End Try
            Try
                Finiquitos.PJustificacion = CStr(row("fini_justificacion"))
            Catch ex As Exception

            End Try

            colaborador.PFiniquitos = Finiquitos
            colaborador.PMotivosFiniquito = MotivoFiniquito
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
            If Not IsDBNull(row("codr_telefonocasa")) Then
                colaborador.PTelefonoCasa = CStr(row("codr_telefonocasa"))
            End If
            colaborador.PTelefonoCel = CStr(row("codr_telefonocelular"))
            ListaColaboradoresFiltroCompletoCURP.Add(colaborador)
        Next

        Return ListaColaboradoresFiltroCompletoCURP
    End Function

    Public Function ConcentradoAltas(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Naveid As Int32) As DataTable
        Dim objDa As New ColaboradoresDA
        Return objDa.ConcentradoColaboradores(FechaInicio, FechaFin, Naveid)
    End Function

    Public Function ConcentradoCumpleaños(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Naveid As Int32) As DataTable
        Dim objDa As New ColaboradoresDA
        Return objDa.ConcentradoCumpleaños(FechaInicio, FechaFin, Naveid)
    End Function

    Public Function ConcentradoIMSS(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Naveid As Int32) As DataTable
        Dim objDa As New ColaboradoresDA
        Return objDa.ConcentradoIMSS(FechaInicio, FechaFin, Naveid)
    End Function
    Public Function ConcentradoDeduccionesExtraordinarias(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Naveid As Int32) As DataTable
        Dim objDa As New ColaboradoresDA
        Return objDa.ConcentradoDeduccionesExtraordinarias(FechaInicio, FechaFin, Naveid)
    End Function

    Public Function listaColaboradorVigilanteNocturno(ByVal naveID As Integer) As List(Of Integer)
        Dim objDa As New ColaboradoresDA
        Dim tblVigilanteNocturno As New DataTable
        listaColaboradorVigilanteNocturno = New List(Of Integer)
        tblVigilanteNocturno = objDa.listaColaboradorVigilanteNocturno(naveID)
        Dim colaboradorID As Integer
        For Each row As DataRow In tblVigilanteNocturno.Rows

            colaboradorID = CInt(row("codr_colaboradorid"))
            listaColaboradorVigilanteNocturno.Add(colaboradorID)
        Next

        Return listaColaboradorVigilanteNocturno
    End Function

    Public Function buscarColaboradorVigilanteNocturno(ByVal naveID As Integer, ByVal colaboradorID As Integer) As Boolean
        Dim objDa As New ColaboradoresDA
        Dim tblVigilanteNocturno As New DataTable

        tblVigilanteNocturno = objDa.colaboradorVigilanteNocturno(naveID, colaboradorID)

        If tblVigilanteNocturno.Rows.Count > 0 Then

            Return True

        Else

            Return False

        End If

    End Function


    Public Sub DesactivarColaborador(ByVal ColaboradorID As Int32)
        Dim objda As New Datos.ColaboradoresDA
        objda.DesactivarColaborador(ColaboradorID)
    End Sub




    Public Function CredencialesJeans(ByVal Colaboradorid As Int32) As Entidades.Credenciales
        Dim objda As New Datos.ColaboradoresDA
        Dim tabla As New DataTable
        tabla = objda.CredencialesJeans(Colaboradorid)
        Dim Entidad As New Entidades.Credenciales
        For Each row As DataRow In tabla.Rows
            Entidad.Papellidos = CStr(row("apellidos"))
            Entidad.Parea_nombre = CStr(row("area_nombre"))
            Entidad.Pcodigo = CStr(row("codigo"))
            Entidad.Pcodr_colaboradorid = CStr(row("codr_colaboradorid"))
            Entidad.Pcodr_nombre = CStr(row("codr_nombre"))
            Entidad.Pfoto = CStr(row("foto"))
            Entidad.Pgrup_name = CStr(row("grup_name"))
            Entidad.Ppues_nombre = CStr(row("pues_nombre"))
        Next
        Return Entidad
    End Function

    Public Function CredencialesTodo(ByVal Colaboradorid As Int32) As Entidades.Credenciales
        Dim objda As New Datos.ColaboradoresDA
        Dim tabla As New DataTable
        tabla = objda.CredencialesTodo(Colaboradorid, rutaPublica)
        Dim Entidad As New Entidades.Credenciales
        For Each row As DataRow In tabla.Rows
            Entidad.Papellidos = CStr(row("apellidos"))
            Entidad.Parea_nombre = CStr(row("area_nombre"))
            Entidad.Pcodigo = CStr(row("codigo"))
            Entidad.Pcodr_colaboradorid = CStr(row("codr_colaboradorid"))
            Entidad.Pcodr_nombre = CStr(row("codr_nombre"))
            Entidad.Pfoto = CStr(row("foto"))
            Entidad.Pgrup_name = CStr(row("grup_name"))
            Entidad.Ppues_nombre = CStr(row("pues_nombre"))
            Entidad.Pgrup_name = CStr(row("grup_name"))
            Entidad.PNave = CStr(row("idNave"))
        Next
        Return Entidad
    End Function


    Public Function ListaEmpleadosDiaAdicional(ByVal Naveid As Int32, ByVal Periodo As Int32, ByVal nombreColaborador As String,
                                               ByVal idDepartamento As Int32, ByVal idPuesto As Int32,
                                               ByVal idCelula As Int32, ByVal fecha As String,
                                               ByVal verHoras As Boolean) As DataTable
        Dim objda As New Datos.ColaboradoresDA
        Return objda.ListaEmpleadosDiaAdicional(Naveid, Periodo, nombreColaborador,
                                                  idDepartamento, idPuesto,
                                                  idCelula, fecha, verHoras)

    End Function

    Public Function consultarDatosColaboradorporUsuario(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.ColaboradoresDA
        Dim dtColaborador As New DataTable
        dtColaborador = objDa.consultarDatosColaboradorporUsuario(idUsuario)
        Return dtColaborador
    End Function

    Public Function validaSolicitudImss(ByVal Colaboradorid As Int32) As Boolean
        Dim objDa As New Datos.ColaboradoresDA
        Dim dtValida As New DataTable
        Dim valida As Boolean = False

        dtValida = objDa.validaSolicitudImss(Colaboradorid)

        If dtValida.Rows.Count > 0 Then
            valida = dtValida.Rows(0).Item("existeSolicitud")
        End If
        Return valida
    End Function

    Public Function consultarPatronPorNavesUsuario(ByVal usuarioId As Integer) As DataTable
        Dim objDatos As New Datos.ColaboradoresDA
        Dim dtListado As New DataTable

        dtListado = objDatos.consultarPatronPorNavesUsuario(usuarioId)
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 1 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("ID") = 0
                dtRow("PATRON") = ""
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function

    Public Function obtenerDimensionesCredencial(ByVal Naveid As Int32) As DataTable
        Dim objDA As New Datos.ColaboradoresDA
        Return objDA.obtenerDimensionesCredencial(Naveid)
    End Function

    Public Function ObtenerNombreColaboradorCredencialEspecial(ByVal ColaboradorId As Integer) As DataTable
        Dim objDA As New Datos.ColaboradoresDA
        Return objDA.ObtenerNombreColaboradorCredencialEspecial(ColaboradorId)
    End Function
End Class
