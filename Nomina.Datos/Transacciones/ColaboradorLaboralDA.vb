Public Class ColaboradorLaboralDA
    Public Function buscarInformacionLaboral(ByVal colaboradorId As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Nomina.ColaboradorLaboral as a"
        consulta += " left JOIN Framework.Naves as b on(a.labo_naveid=b.nave_naveid)"
        consulta += " left JOIN Framework.Grupos as c on(a.labo_departamentoid=c.grup_grupoid)"
        consulta += " left JOIN Nomina.Puestos as d on (a.labo_puestoid=d.pues_puestoid)"
        consulta += " left JOIN Nomina.Celulas as e on (labo_celulaid = celu_celulaid)"
        consulta += " left JOIN Nomina.Horarios as f on(hora_horarioid= labo_horarioid)"
        consulta += " WHERE labo_colaboradorid=" + colaboradorId.ToString
        consulta = consulta
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function BuscarDatosColaborador(ByVal ColaboradorID As Int32) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        'Dim Consulta As String = "select * from  Nomina.Colaborador left join Nomina.ColaboradorLaboral on ( codr_colaboradorid = labo_colaboradorid) join Framework.Ciudades on (codr_ciudadid= city_ciudadid) "
        Dim Consulta As String = String.Empty

        Consulta &= "select *, cd.city_ciudadid ciudadid, cd.city_estadoid estadoid, cdo.city_ciudadid ciudadorigenid, cdo.city_estadoid estadoorigenid" & vbCrLf
        Consulta &= "from  Nomina.Colaborador c" & vbCrLf
        Consulta &= "left join Nomina.ColaboradorLaboral cl on (c.codr_colaboradorid = cl.labo_colaboradorid) " & vbCrLf
        Consulta &= "join Framework.Ciudades cd on (c.codr_ciudadid = cd.city_ciudadid) " & vbCrLf
        Consulta &= "join Framework.Ciudades cdo on (c.codr_idciudadorigen = cdo.city_ciudadid) " & vbCrLf
        Consulta &= " where codr_colaboradorid=" + ColaboradorID.ToString
        Return Operaciones.EjecutaConsulta(Consulta)
    End Function




    Public Sub insertarcolaborador(ByVal col As Entidades.ColaboradorLaboral)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros = New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "colaboradorid"
        parametro.Value = col.PColaboradorId.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = col.PNaveId.PNaveId
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "depto"
        parametro.Value = col.PDepartamentoId.Ddepartamentoid
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "puesto"
        parametro.Value = col.PPuestoId.Ppuestosid
        listaParametros.Add(parametro)

        If col.PCelula.PCelulaid <= 0 Then
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "celula"
            parametro.Value = DBNull.Value
            listaParametros.Add(parametro)

        Else
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "celula"
            parametro.Value = col.PCelula.PCelulaid
            listaParametros.Add(parametro)
        End If

        If col.PHorarioId.DHorariosid <= 0 Then

        End If

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "horario"
        parametro.Value = col.PHorarioId.DHorariosid
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "horario2"
        If col.PHorario2Id.DHorariosid = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = col.PHorario2Id.DHorariosid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "areaid"
        parametro.Value = col.PAreaID
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "nip"
        parametro.Value = col.PNIP
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "horasextras"
        parametro.Value = col.PGeneraHorasExtras
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "checa"
        parametro.Value = col.PCheca
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "reporte"
        parametro.Value = col.PReporte
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@ganaincentivos"
        parametro.Value = col.PGanaIncentivos
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@telefono"
        parametro.Value = col.telefono
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@extencion"
        parametro.Value = col.extencion
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@email"
        parametro.Value = col.emailLaboral
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@jefeInmediato"
        parametro.Value = col.jefeInmediato
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idJefe"
        parametro.Value = col.jefeInmediatoid
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idHuellaExterno"
        parametro.Value = col.PhuellaExterno
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@tieneLicencia"
        parametro.Value = col.PTieneLicencia
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@numLicencia"
        parametro.Value = col.PNumLicencia
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@fechaVigenteLicencia"
        parametro.Value = col.PFechaVigencia
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("Nomina.SP_altas_colaboradorlaboral", listaParametros)
    End Sub



    Public Sub Editarcolaborador(ByVal col As Entidades.ColaboradorLaboral, ByVal colaboradorId As Int32)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros = New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "colaboradorid"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = col.PNaveId.PNaveId
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "depto"
        parametro.Value = col.PDepartamentoId.Ddepartamentoid
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "puesto"
        parametro.Value = col.PPuestoId.Ppuestosid
        listaParametros.Add(parametro)

        If col.PCelula.PCelulaid <= 0 Then
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "celula"
            parametro.Value = DBNull.Value
            listaParametros.Add(parametro)

        Else
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "celula"
            parametro.Value = col.PCelula.PCelulaid
            listaParametros.Add(parametro)
        End If


        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "horario"
        parametro.Value = col.PHorarioId.DHorariosid
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "horario2"
        If col.PHorario2Id.DHorariosid = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = col.PHorario2Id.DHorariosid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "areaid"
        parametro.Value = col.PAreaID
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "nip"
        parametro.Value = col.PNIP
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "horasextras"
        parametro.Value = col.PGeneraHorasExtras
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "checa"
        parametro.Value = col.PCheca
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "reporte"
        parametro.Value = col.PReporte
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@ganaincentivos"
        parametro.Value = col.PGanaIncentivos
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@telefono"
        parametro.Value = col.telefono
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@extencion"
        parametro.Value = col.extencion
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@email"
        parametro.Value = col.emailLaboral
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@jefeInmediato"
        parametro.Value = col.jefeInmediato
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idJefe"
        parametro.Value = col.jefeInmediatoid
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idHuellaExterno"
        parametro.Value = col.PhuellaExterno
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@tieneLicencia"
        parametro.Value = col.PTieneLicencia
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@numLicencia"
        parametro.Value = col.PNumLicencia
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@fechaExpiraLicencia"
        parametro.Value = col.PFechaVigencia
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("Nomina.SP_Editar_Colaborador_Laboral", listaParametros)

    End Sub


    Public Sub ActualizarIdAnual(ByVal Naveid As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos


        Dim listaParametros = New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@naveID"
        parametro.Value = Naveid
        listaParametros.Add(parametro)
        operaciones.EjecutarSentenciaSP("Nomina.SP_Actualizar_codr_idanual", listaParametros)
    End Sub

    Public Function getColaboradoresDepartamento(ByVal idDep As Int32, ByVal Naveid As Int32) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        'Dim Consulta As String =
        '    <caden>
        '    select 0 'id','' 'colaborador' union 
        '    select codr_colaboradorid 'id',codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno 'colaborador' from Nomina.Colaborador 
        '    inner join Nomina.ColaboradorLaboral on codr_colaboradorid=labo_colaboradorid  where codr_activo=1
        '    and labo_departamentoid=<%= idDep %>
        '    order by colaborador
        '    </caden>
        'Return Operaciones.EjecutaConsulta(Consulta)
        Dim listaParametros = New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@departamentoID"
        parametro.Value = idDep
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@naveID"
        parametro.Value = Naveid
        listaParametros.Add(parametro)

        Return Operaciones.EjecutarConsultaSP("Nomina.SP_Nomina_ColaboradoresDepartamento", listaParametros)

    End Function

End Class
