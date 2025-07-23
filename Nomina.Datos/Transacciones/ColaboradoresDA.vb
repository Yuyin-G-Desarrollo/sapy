Imports System.Data.SqlClient

Public Class ColaboradoresDA
    Public Function listaColaboradores(ByVal Nombre As String, ByVal Curp As String, ByVal Rfc As String, ByVal activo As Boolean) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Nomina.Colaborador"
        consulta += " WHERE (codr_nombre +' ' +codr_apellidopaterno+' ' + codr_apellidomaterno) like '%" + Nombre.Replace(" ", "%") + "%'"
        consulta += " AND codr_curp LIKE '%" + Curp + "%'"
        consulta += " AND codr_rfc LIKE '%" + Rfc + "%'"
        consulta += " AND codr_activo = '" + activo.ToString + "'"

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaColaboradoresNave(ByVal NaveId As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT c.codr_colaboradorid as IdColaborador, (c.codr_nombre + ' ' + c.codr_apellidopaterno + ' ' + c.codr_apellidomaterno) as NombreColaborador FROM Nomina.Colaborador c " &
                                    "INNER JOIN Nomina.ColaboradorLaboral cl ON c.codr_colaboradorid = cl.labo_colaboradorid " &
                                 "WHERE cl.labo_naveid = " + NaveId.ToString

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaColaboradoresDepto(ByVal DeptoId As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT c.codr_colaboradorid as IdColaborador, (c.codr_nombre + ' ' + c.codr_apellidopaterno + ' ' + c.codr_apellidomaterno) as NombreColaborador " &
                                 "FROM Nomina.Colaborador c " &
                                 "INNER JOIN Nomina.ColaboradorLaboral cl ON c.codr_colaboradorid = cl.labo_colaboradorid " &
                                 "WHERE cl.labo_departamentoid = " + DeptoId.ToString + "AND c.codr_activo = 1 order by NombreColaborador"

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaColaboradoresCelula(ByVal celulaID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT c.codr_colaboradorid as IdColaborador, (c.codr_nombre + ' ' + c.codr_apellidopaterno + ' ' + c.codr_apellidomaterno) as NombreColaborador " +
                                 " FROM Nomina.Colaborador c " +
                                 " INNER JOIN Nomina.ColaboradorLaboral cl ON c.codr_colaboradorid = cl.labo_colaboradorid " +
                                 " WHERE cl.labo_celulaid = " + celulaID.ToString + "AND c.codr_activo = 1" +
                                 " ORDER BY NombreColaborador"

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    'Public Function listaColaboradoresFiltroCompleto(ByVal Nombre As String, ByVal Curp As String, ByVal RFC As String _
    '                                                 , ByVal activo As Boolean, ByVal idNave As Int32, ByVal idDepartamento As Int32, _
    '                                                 ByVal puesto As Int32, ByVal externo As Boolean) As DataTable
    '    Dim operaciones As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String = "SELECT * FROM Nomina.Colaborador left join Nomina.ColaboradorLaboral "
    '    consulta += "on (codr_colaboradorid = labo_colaboradorid) join Nomina.ColaboradorReal on (codr_colaboradorid=real_colaboradorid) "
    '    consulta += "left join Framework.Grupos on (labo_departamentoid = grup_grupoid) "
    '    consulta += "left Join Framework.Naves on (labo_naveid = nave_naveid) "
    '    consulta += "left join Nomina.Puestos on (labo_puestoid = pues_puestoid)"
    '    consulta += "left join Framework.NavesUsuario on(naus_naveid = labo_naveid)"
    '    consulta += "LEFT JOIN Nomina.ColaboradorNomina on (codr_colaboradorid=cono_colaboradorid)"
    '    consulta += " WHERE naus_usuarioid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + " and (codr_nombre +' ' +codr_apellidopaterno+' ' + codr_apellidomaterno) like '%" + Nombre.Replace(" ", "%") + "%'"
    '    consulta += " AND codr_curp LIKE '%" + Curp + "%'"
    '    consulta += " AND codr_rfc LIKE '%" + RFC + "%'"
    '    consulta += " AND codr_activo = '" + activo.ToString + "'"
    '    consulta += " AND isnull(cono_externo, 'false')= '" + externo.ToString + "'"
    '    If idNave > 0 Then
    '        consulta += " And labo_naveid= " + idNave.ToString
    '    End If
    '    If idDepartamento > 0 Then
    '        consulta += " And labo_departamentoid=" + idDepartamento.ToString
    '    End If
    '    If puesto > 0 Then
    '        consulta += " And labo_puestoid=" + puesto.ToString
    '    End If
    '    consulta += " order by real_fecha"
    '    Return operaciones.EjecutaConsulta(consulta)
    'End Function

    Public Function listaColaboradoresFiltroCompleto(ByVal Filtros As Entidades.FiltrosFichaColaborador) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Nombre"
        parametro.Value = Filtros.PNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CURP"
        parametro.Value = Filtros.PCURP
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RFC"
        parametro.Value = Filtros.PRFC
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Filtros.PActivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdNave"
        parametro.Value = Filtros.PIdNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdDepartamento"
        parametro.Value = Filtros.PIdDepartamento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Puesto"
        parametro.Value = Filtros.PIdPuesto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Externo"
        parametro.Value = Filtros.PExterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ListaColaboradoresFiltroCompleto]", listaParametros)
    End Function


    Public Function listaColaboradoresFiltroCompletoGeneranHorasExtras(ByVal Nombre As String, ByVal Curp As String, ByVal RFC As String _
                                                   , ByVal activo As Boolean, ByVal idNave As Int32, ByVal idDepartamento As Int32, _
                                                   ByVal puesto As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Nomina.Colaborador left join Nomina.ColaboradorLaboral "
        consulta += "on (codr_colaboradorid = labo_colaboradorid) "
        consulta += "left join Framework.Grupos on (labo_departamentoid = grup_grupoid) "
        consulta += "left Join Framework.Naves on (labo_naveid = nave_naveid) "
        consulta += "left join Nomina.Puestos on (labo_puestoid = pues_puestoid)"
        consulta += "left join Framework.NavesUsuario on(naus_naveid = labo_naveid)"
        consulta += " WHERE naus_usuarioid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + " and (codr_nombre +' ' +codr_apellidopaterno+' ' + codr_apellidomaterno) like '%" + Nombre.Replace(" ", "%") + "%'"
        consulta += " AND codr_curp LIKE '%" + Curp + "%'"
        consulta += " AND codr_rfc LIKE '%" + RFC + "%'"
        consulta += " AND codr_activo = '" + activo.ToString + "' and labo_generahorasextras = 1"
        If idNave > 0 Then
            consulta += " And labo_naveid= " + idNave.ToString
        End If
        If idDepartamento > 0 Then
            consulta += " And labo_departamentoid=" + idDepartamento.ToString
        End If
        If puesto > 0 Then
            consulta += " And labo_puestoid=" + puesto.ToString
        End If

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaColaboradoresFiltroCompletoCURP(ByVal Nombre As String, ByVal Curp As String, ByVal RFC As String _
                                                 , ByVal idNave As Int32, ByVal idDepartamento As Int32, _
                                                 ByVal puesto As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Nomina.Colaborador left join Nomina.ColaboradorLaboral "
        consulta += "on (codr_colaboradorid = labo_colaboradorid) "
        consulta += "left join Framework.Grupos on (labo_departamentoid = grup_grupoid) "
        consulta += "left Join Framework.Naves on (labo_naveid = nave_naveid) "
        consulta += "left join Nomina.Puestos on (labo_puestoid = pues_puestoid) left join Nomina.Finiquitos on (codr_colaboradorid=fini_colaboradorid) left join Nomina.MotivosFiniquito on (fini_motivofiniquitoid= mfin_motivofiniquitoid)"
        consulta += " WHERE (codr_nombre +' ' +codr_apellidopaterno+' ' + codr_apellidomaterno) like '%" + Nombre.Replace(" ", "%") + "%'"
        consulta += " AND codr_curp LIKE '%" + Curp + "%'"
        consulta += " AND codr_rfc LIKE '%" + RFC + "%'"

        If idNave > 0 Then
            consulta += " And labo_naveid= " + idNave.ToString
        End If
        If idDepartamento > 0 Then
            consulta += " And labo_departamentoid=" + idDepartamento.ToString
        End If
        If puesto > 0 Then
            consulta += " And labo_puestoid=" + puesto.ToString
        End If

        Return operaciones.EjecutaConsulta(consulta)
    End Function




    Public Function ListaEmpleados(ByVal nombre As String, ByVal IDUSUARIO As Int32, ByVal naveid As Int32) As DataTable ''declaramos el metodo como Datatable es nuestra consulta

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos ''Conexion y operaciones
        Dim consulta As String = "select * from Nomina.Colaborador as a left join Nomina.ColaboradorLaboral as b on a.codr_colaboradorid=b.labo_colaboradorid left join Framework.Naves as c on b.labo_naveid=c.nave_naveid left join Framework.Grupos on labo_departamentoid=grup_grupoid left join Nomina.Puestos as w on b.labo_puestoid = w.pues_puestoid left join Nomina.Celulas as d on (b.labo_celulaid= d.celu_celulaid) LEFT JOIN Nomina.ColaboradorReal as cr ON (a.codr_colaboradorid = cr.real_colaboradorid) where  ((a.codr_nombre + ' '+codr_apellidopaterno + ' ' + codr_apellidomaterno) like '%"


        consulta += nombre.Replace(" ", "%") + "%' "
        consulta += "OR a.codr_curp like '%" + nombre.Replace(" ", "%") + "%' "
        consulta += "OR a.codr_rfc like '%" + nombre.Replace(" ", "%") + "%' )"
        If IDUSUARIO > 0 Then
            consulta += " and b.labo_naveid=" + naveid.ToString + " and codr_activo =1"
        End If
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function ListaEmpleadosDiaAdicional(ByVal Naveid As Int32, ByVal Periodo As Int32, ByVal nombreColaborador As String,
                                               ByVal idDepartamento As Int32, ByVal idPuesto As Int32,
                                               ByVal idCelula As Int32, ByVal fecha As String,
                                               ByVal verHoras As Boolean) As DataTable
        Dim idUsuarioL As Int32 = 0
        If Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid > 0 Then
            idUsuarioL = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        End If

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos ''Conexion y operaciones

        Dim consulta As String = "SELECT CAST(0 as BIT) AS Seleccion, cb.codr_colaboradorid 'ID', cb.codr_fechanacimiento 'NACIMIENTO'," +
            " cb.codr_nombre + ' ' + cb.codr_apellidopaterno + ' ' + cb.codr_apellidomaterno AS 'NOMBRE'," +
            " cl.labo_colaboradorlaboralid AS 'IDLABORAL', cl.labo_GanaIncentivosSiempre 'SIINCENTIVOS', cl.labo_naveid AS 'IDNAVE', nv.nave_nombre 'NAVE'," +
            " cl.labo_departamentoid AS 'IDDEPARTAMENTO', dep.grup_name 'DEPARTAMENTO', cel.celu_celulaid 'IDCELULA', cel.celu_nombre 'CELULA'," +
            " ps.pues_puestoid 'IDPUESTO', ps.pues_nombre 'PUESTO', ISNULL(cr.real_cantidad, 0) AS 'Salario'," +
            " 0 AS DiaAdicional,"

        consulta += " cr.real_tipo 'TipoSalario',"

        If verHoras = True Then
            consulta += " (Nomina.FN_ConcatenarHorasChecoDia(cb.codr_colaboradorid, '" + fecha + "')) AS HORASCHECO,"
        End If

        consulta += " DATEDIFF(DAY, cr.real_fecha, GETDATE()) AS antiguedad" +
            " FROM Nomina.Colaborador AS cb" +
            " LEFT JOIN Nomina.ColaboradorLaboral AS cl ON cb.codr_colaboradorid = cl.labo_colaboradorid" +
            " JOIN Nomina.ColaboradorReal cr ON cb.codr_colaboradorid = cr.real_colaboradorid" +
            " LEFT JOIN Framework.Naves AS nv ON cl.labo_naveid = nv.nave_naveid" +
            " LEFT JOIN Framework.Grupos dep ON cl.labo_departamentoid = dep.grup_grupoid" +
            " LEFT JOIN Nomina.Puestos AS ps ON  cl.labo_puestoid = ps.pues_puestoid" +
            " LEFT JOIN Nomina.Celulas AS cel ON (cl.labo_celulaid = cel.celu_celulaid)" +
            " WHERE codr_activo = 1" +
            "and ((cb.codr_nombre + ' '+cb.codr_apellidopaterno + ' ' + cb.codr_apellidopaterno) like '%" +
            nombreColaborador.Replace(" ", "%") + "%' " +
            "OR cb.codr_curp like '%" + nombreColaborador.Replace(" ", "%") + "%' " +
            "OR cb.codr_rfc like '%" + nombreColaborador.Replace(" ", "%") + "%' ) and cl.labo_naveid=" + Naveid.ToString
        ' -------------------------------------------------------{
        Dim Consultados As String = "select naus_naveid from Framework.NavesUsuario" +
            " where naus_usuarioid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        Dim Tabla As New DataTable
        Tabla = objOperaciones.EjecutaConsulta(Consultados)
        If Tabla.Rows.Count >= 2 Then
            consulta += " and nv.nave_naveid in ("
            For Each row As DataRow In Tabla.Rows
                consulta += CStr(row("naus_naveid")) + ", "
            Next
            consulta += " 0)"
        Else
            Try
                consulta += "and nv.nave_naveid=(select naus_naveid from Framework.NavesUsuario" +
                    " where codr_activo=1 and naus_usuarioid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ")"
            Catch ex As Exception

            End Try
        End If
        '--------------------------------------------------------}
        If idDepartamento > 0 Then
            consulta += " AND cl.labo_departamentoid = " + idDepartamento.ToString
        End If
        If idPuesto > 0 Then
            consulta += " AND ps.pues_puestoid = " + idPuesto.ToString
        End If

        If idCelula > 0 Then
            consulta += "  AND cel.celu_celulaid = " + idCelula.ToString
        End If

        consulta += " AND cb.codr_activo = 1"

        'consulta += " AND  labo_colaboradorid NOT IN (SELECT soin_colaboradorid FROM Nomina.SolicitudIncentivos WHERE soin_motivoincentivoid IN" +
        '    " (SELECT moin_motivoincentivoid FROM Nomina.MotivosIncentivos WHERE moin_diaadicional = 1) AND soin_periodonominapagado = " + Periodo.ToString + ")"

        If Not IsDBNull(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser) And Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser > 0 Then
            consulta += "and cl.labo_naveid IN (SELECT naus_naveid from Framework.NavesUsuario" +
                " JOIN Framework.Naves on (naus_naveid=nave_naveid)" +
                " where naus_usuarioid= " + idUsuarioL.ToString + "and nave_activo='True')" +
                " and labo_naveid in (select naus_naveid from Framework.NavesUsuario" +
                " where naus_usuarioid= " + idUsuarioL.ToString + ") and" +
                " codr_activo =1 and grup_grupoid IN (SELECT dept_departamentoid" +
                " FROM Nomina.encargadodepartamento" +
                " WHERE dept_colaboradorid= " + Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser.ToString + ") and codr_activo=1"
        End If
        consulta += " ORDER BY  grup_name, antiguedad, NOMBRE, pues_nombre"

        'If Not IsDBNull(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser) Then
        Return objOperaciones.EjecutaConsulta(consulta)
        'End If


    End Function


    Public Function ListaEmpleadosSegunDepartamentoUsuarioConsulta(ByVal nombre As String, ByVal IDUSUARIO As Int32,
                                                                   ByVal Naveid As Int32, ByVal Periodo As Int32) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos ''Conexion y operaciones

        Dim consulta As String = "select codr_colaboradorid, codr_fechanacimiento, codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno as NOMBRE," +
        " labo_colaboradorlaboralid, labo_naveid, labo_departamentoid, labo_GanaIncentivosSiempre, nave_naveid," +
        " nave_nombre, grup_grupoid, grup_name, celu_celulaid, celu_nombre, pues_puestoid, pues_nombre, DATEDIFF(DAY, cr.real_fecha, GETDATE()) as antiguedad" +
        " from Nomina.Colaborador as a" +
        " left join Nomina.ColaboradorLaboral as b on a.codr_colaboradorid=b.labo_colaboradorid" +
        " JOIN Nomina.ColaboradorReal cr ON a.codr_colaboradorid = cr.real_colaboradorid" +
        " left join Framework.Naves as c on b.labo_naveid=c.nave_naveid" +
        " left join Framework.Grupos on labo_departamentoid=grup_grupoid" +
        " left join Nomina.Puestos as w on b.labo_puestoid = w.pues_puestoid" +
        " left join Nomina.Celulas as d on (b.labo_celulaid= d.celu_celulaid)" +
        " where  codr_activo=1 and ((a.codr_nombre + ' '+codr_apellidopaterno + ' ' + codr_apellidomaterno) like '%"
        consulta += nombre.Replace(" ", "%") + "%' "
        consulta += "OR a.codr_curp like '%" + nombre.Replace(" ", "%") + "%' "
        consulta += "OR a.codr_rfc like '%" + nombre.Replace(" ", "%") + "%' ) and labo_naveid=" + Naveid.ToString

        Dim Consultados As String = "select naus_naveid from Framework.NavesUsuario" +
            " where naus_usuarioid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        Dim Tabla As New DataTable

        Tabla = objOperaciones.EjecutaConsulta(Consultados)

        If Tabla.Rows.Count >= 2 Then
            consulta += " and c.nave_naveid in ("
            For Each row As DataRow In Tabla.Rows
                consulta += CStr(row("naus_naveid")) + ", "
            Next
            consulta += " 0)"
        Else
            Try
                consulta += "and c.nave_naveid=(select naus_naveid from Framework.NavesUsuario" +
                    " where codr_activo=1 and naus_usuarioid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ")"
            Catch ex As Exception

            End Try
        End If

        consulta += " AND a.codr_colaboradorid NOT IN (SELECT soin_colaboradorid FROM Nomina.SolicitudIncentivos WHERE soin_estado = 'A' AND soin_motivoincentivoid NOT IN (SELECT moin_motivoincentivoid FROM Nomina.MotivosIncentivos WHERE moin_diaadicional = 1 AND moin_activo = 1) AND soin_periodonominapagado = " + Periodo.ToString + ")"

        If Not IsDBNull(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser) And Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser > 0 Then
            consulta += "and b.labo_naveid IN (SELECT naus_naveid from Framework.NavesUsuario" +
                " JOIN Framework.Naves on (naus_naveid=nave_naveid)" +
                " where naus_usuarioid= " + IDUSUARIO.ToString + "and nave_activo='True')" +
                " and labo_naveid in (select naus_naveid from Framework.NavesUsuario" +
                " where naus_usuarioid= " + IDUSUARIO.ToString + ") and" +
                " codr_activo =1 and grup_grupoid IN (SELECT dept_departamentoid" +
                " FROM Nomina.encargadodepartamento" +
                " WHERE dept_colaboradorid= " + Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser.ToString + ") and codr_activo=1"
        End If
        consulta += " ORDER BY  grup_name, antiguedad, NOMBRE, pues_nombre"

        'If Not IsDBNull(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser) Then
        Return objOperaciones.EjecutaConsulta(consulta)
        'End If


    End Function

    Public Function ListaEmpleadosSegunDepartamentoUsuario(ByVal nombre As String, ByVal IDUSUARIO As Int32, ByVal Naveid As Int32) As DataTable ''declaramos el metodo como Datatable es nuestra consulta
        'ELIMINAR
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos ''Conexion y operaciones

        Dim consulta As String = "select * from Nomina.Colaborador as a" +
        " left join Nomina.ColaboradorLaboral as b on a.codr_colaboradorid=b.labo_colaboradorid" +
        " left join Framework.Naves as c on b.labo_naveid=c.nave_naveid" +
        " left join Framework.Grupos on labo_departamentoid=grup_grupoid" +
        " left join Nomina.Puestos as w on b.labo_puestoid = w.pues_puestoid" +
        " left join Nomina.Celulas as d on (b.labo_celulaid= d.celu_celulaid)" +
        " where  codr_activo=1 and ((a.codr_nombre + ' '+codr_apellidopaterno + ' ' + codr_apellidomaterno) like '%"
        consulta += nombre.Replace(" ", "%") + "%' "
        consulta += "OR a.codr_curp like '%" + nombre.Replace(" ", "%") + "%' "
        consulta += "OR a.codr_rfc like '%" + nombre.Replace(" ", "%") + "%' ) and labo_naveid=" + Naveid.toString

        Dim Consultados As String = "select naus_naveid from Framework.NavesUsuario" +
            " where naus_usuarioid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        Dim Tabla As New DataTable

        Tabla = objOperaciones.EjecutaConsulta(Consultados)

        If Tabla.Rows.Count >= 2 Then
            consulta += " and c.nave_naveid in ("
            For Each row As DataRow In Tabla.Rows
                consulta += CStr(row("naus_naveid")) + ", "
            Next
            consulta += " 0)"
            'consulta += " and ("
            'Dim indice As Int32 = 0
            'For Each row As DataRow In Tabla.Rows
            '    If indice = 0 Then
            '        consulta += " c.nave_naveid=" + CStr(row("naus_naveid")) + ""
            '        indice = 1
            '    Else
            '        consulta += " or c.nave_naveid=" + CStr(row("naus_naveid")) + ""
            '    End If

            'Next
            'consulta += " )"
        Else
            Try
                consulta += "and c.nave_naveid=(select naus_naveid from Framework.NavesUsuario" +
                    " where codr_activo=1 and naus_usuarioid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ")"
            Catch ex As Exception

            End Try
        End If

        If Not IsDBNull(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser) And Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser > 0 Then
            consulta += "and b.labo_naveid IN (SELECT naus_naveid from Framework.NavesUsuario" +
                " JOIN Framework.Naves on (naus_naveid=nave_naveid)" +
                " where naus_usuarioid= " + IDUSUARIO.ToString + "and nave_activo='True')" +
                " and labo_naveid in (select naus_naveid from Framework.NavesUsuario" +
                " where naus_usuarioid= " + IDUSUARIO.ToString + ") and" +
                " codr_activo =1 and grup_grupoid IN (SELECT dept_departamentoid" +
                " FROM Nomina.encargadodepartamento" +
                " WHERE dept_colaboradorid= " + Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser.ToString + ") and codr_activo=1"
        End If


        'If Not IsDBNull(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser) Then
        Return objOperaciones.EjecutaConsulta(consulta)
        'End If


    End Function
    Public Sub AgregarColaborador(ByVal col As Entidades.Colaborador)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = col.PNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "paterno"
        parametro.Value = col.PApaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "materno"
        parametro.Value = col.PAmaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "curp"
        parametro.Value = col.pCurp
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rfc"
        parametro.Value = col.PRfc
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nacimiento"
        parametro.Value = col.PFechaNacimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estadocivil"
        parametro.Value = col.PEstadoCivil
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "calle"
        parametro.Value = col.PCalle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numero"
        parametro.Value = col.Pnumero
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colonia"
        parametro.Value = col.Pcolonia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ciudad"
        parametro.Value = col.PCiudad.CciudadId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "telefonocasa"
        parametro.Value = col.PTelefonoCasa
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "telefonocelular"
        parametro.Value = col.PTelefonoCel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = True
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cp"
        parametro.Value = col.PCP
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "email"
        parametro.Value = col.PEmail
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sexo"
        parametro.Value = col.PSexo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "claveElector"
        parametro.Value = col.PClaveElector
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ciudadorigenid"
        parametro.Value = col.PCiudadOrigen.CciudadId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombrecorto"
        parametro.Value = col.PNombreCorto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "entrecalles"
        parametro.Value = col.PEntreCalles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domicilioreferencia"
        parametro.Value = col.PReferencia
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("Nomina.SP_altas_colaborador", listaParametros)
    End Sub

    Public Function buscarColaboradorId() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT max(codr_colaboradorid) FROM Nomina.Colaborador"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function buscarColaboradorGeneral(ByVal col As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Framework.Ciudades join Nomina.Colaborador on (codr_ciudadid = city_ciudadid) where codr_colaboradorid=" + col.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function buscarColaboradorPorCURP(ByVal CURP As String) As DataTable
        Dim ObjOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.Colaborador where codr_curp =  '" + CURP.ToString + "'"
        Return ObjOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Sub EditarColaborador(ByVal col As Entidades.Colaborador, ByVal ColaboradorId As Int32)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "colaboradorid"
        parametro.Value = ColaboradorId
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = col.PNombre
        listaParametros.Add(parametro)



        parametro = New SqlParameter
        parametro.ParameterName = "paterno"
        parametro.Value = col.PApaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "materno"
        parametro.Value = col.PAmaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "curp"
        parametro.Value = col.pCurp
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rfc"
        parametro.Value = col.PRfc
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nacimiento"
        parametro.Value = col.PFechaNacimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estadocivil"
        parametro.Value = col.PEstadoCivil
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "calle"
        parametro.Value = col.PCalle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numero"
        parametro.Value = col.Pnumero
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colonia"
        parametro.Value = col.Pcolonia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ciudad"
        parametro.Value = col.PCiudad.CciudadId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "telefonocasa"
        parametro.Value = col.PTelefonoCasa
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "telefonocelular"
        parametro.Value = col.PTelefonoCel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = True
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cp"
        parametro.Value = col.PCP
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "email"
        parametro.Value = col.PEmail
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sexo"
        parametro.Value = col.PSexo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "claveElector"
        parametro.Value = col.PClaveElector
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ciudadorigenid"
        parametro.Value = col.PCiudadOrigen.CciudadId
        listaParametros.Add(parametro)




        parametro = New SqlParameter
        parametro.ParameterName = "nombrecorto"
        parametro.Value = col.PNombreCorto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "entrecalles"
        parametro.Value = col.PEntreCalles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domicilioreferencia"
        parametro.Value = col.PReferencia
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("Nomina.SP_Editar_Colaborador", listaParametros)
    End Sub



    Public Function ConcentradoColaboradores(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "fechainicial"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFinal"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = Naveid
        listaParametros.Add(parametro)
        Return operaciones.EjecutarConsultaSP("Nomina.SP_ConcentradoAltas", listaParametros)
    End Function


    Public Function ConcentradoCumpleaños(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametroas As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "fechainicial"
        parametro.Value = FechaInicio
        listaparametroas.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFinal"
        parametro.Value = FechaFin
        listaparametroas.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = Naveid
        listaparametroas.Add(parametro)
        Return operaciones.EjecutarConsultaSP("Nomina.SP_ConcentradoCumpleaños", listaparametroas)
    End Function



    Public Function ConcentradoIMSS(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametroas As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "fechainicial"
        parametro.Value = FechaInicio
        listaparametroas.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFinal"
        parametro.Value = FechaFin
        listaparametroas.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = Naveid
        listaparametroas.Add(parametro)
        Return operaciones.EjecutarConsultaSP("Nomina.SP_ConcentradoImss", listaparametroas)
    End Function

    Public Function ConcentradoDeduccionesExtraordinarias(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametroas As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "fechainicial"
        parametro.Value = FechaInicio
        listaparametroas.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFinal"
        parametro.Value = FechaFin
        listaparametroas.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = Naveid
        listaparametroas.Add(parametro)
        Return operaciones.EjecutarConsultaSP("Nomina.SP_ConcentradoDeduccionesExtraordinarias", listaparametroas)
    End Function

    Public Function listaColaboradorVigilanteNocturno(ByVal naveID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT codr_colaboradorid FROM Nomina.Colaborador "
        consulta += "JOIN Nomina.ColaboradorLaboral "
        consulta += "ON labo_colaboradorid = codr_colaboradorid "
        consulta += "JOIN Nomina.Puestos "
        consulta += "ON labo_puestoid = pues_puestoid "
        consulta += "WHERE pues_vigilante_nocturno = 1 "
        consulta += "AND labo_naveid = " + naveID.toString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function colaboradorVigilanteNocturno(ByVal naveID As Integer, ByVal colabordorID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT codr_colaboradorid FROM Nomina.Colaborador "
        consulta += "JOIN Nomina.ColaboradorLaboral "
        consulta += "ON labo_colaboradorid = codr_colaboradorid "
        consulta += "JOIN Nomina.Puestos "
        consulta += "ON labo_puestoid = pues_puestoid "
        consulta += "WHERE pues_vigilante_nocturno = 1 "
        consulta += "AND labo_naveid = " + naveID.ToString
        consulta += "AND labo_colaboradorid = " + colabordorID.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function



    Public Sub DesactivarColaborador(ByVal ColaboradorID As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "UPDATE Nomina.Colaborador SET codr_activo = 0, codr_fechamodificacion = GETDATE() WHERE codr_colaboradorid = " + ColaboradorID.ToString
        operaciones.EjecutaConsulta(Consulta)
    End Sub


    Public Function CredencialesJeans(ByVal Colaboradorid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametroas As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@colaboradorid"
        parametro.Value = Colaboradorid
        listaparametroas.Add(parametro)
        Return operaciones.EjecutarConsultaSP("Nomina.SP_imprimir_credenciales", listaparametroas)
    End Function

    Public Function CredencialesTodo(ByVal Colaboradorid As Int32, ByVal rutaPublica As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>
                     select codr_colaboradorid, '*EM'+CONVERT(nvarchar, codr_colaboradorid)+'*' as codigo,
                     codr_nombre, ' ' +codr_apellidopaterno + ' ' +codr_apellidomaterno as apellidos, grup_name, area_nombre, pues_nombre, '<%= rutapublica %>'+ex.cexp_carpeta+'/'+ex.cexp_nombrearchivo as foto,b.labo_naveid as idNave
                     from Nomina.Colaborador as a
                    join Nomina.ColaboradorLaboral as b on a.codr_colaboradorid=labo_colaboradorid
                    join Nomina.ColaboradorNomina as c on a.codr_colaboradorid=c.cono_colaboradorid
                    join Nomina.ColaboradorReal as d on a.codr_colaboradorid=d.real_colaboradorid
                    join Framework.Grupos as g on g.grup_grupoid=b.labo_departamentoid
                    join Nomina.Areas as ar on ar.area_areaid=b.labo_areaid
                    join Nomina.Puestos as p on b.labo_puestoid=p.pues_puestoid
                    join Nomina.ColaboradorExpediente as ex on ex.cexp_colaboradorid=a.codr_colaboradorid and ex.cexp_credencial='True'
                    where a.codr_activo='true'
                     and a.codr_colaboradorid=<%= Colaboradorid.ToString %>
                    order by a.codr_idanual

                 </cadena>.Value
        Return operaciones.EjecutaConsulta(cadena)
    End Function


    Public Function CredencialesNIZA(ByVal Colaboradorid As Int32, ByVal Naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametroas As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@colaboradorid"
        parametro.Value = Colaboradorid
        listaparametroas.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@naveid"
        parametro.Value = Naveid
        listaparametroas.Add(parametro)
        Return operaciones.EjecutarConsultaSP("Nomina.SP_imprimir_credenciales_hoteles", listaparametroas)
    End Function

    Public Function consultarDatosColaboradorporUsuario(ByVal idUsuario As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = " SELECT c.codr_colaboradorid, (c.codr_nombre + ' ' + c.codr_apellidopaterno + ' '+ c.codr_apellidomaterno) nombre , g.grup_name as departamento, (ce.cexp_carpeta +'/' + ce.cexp_nombrearchivo) ruta , ce.cexp_nombrearchivo as imagen, ce.cexp_carpeta" +
        " FROM Nomina.Colaborador c JOIN Nomina.ColaboradorLaboral cl on c.codr_colaboradorid=cl.labo_colaboradorid " +
        " JOIN Nomina.ColaboradorExpediente ce on ce.cexp_colaboradorid=c.codr_colaboradorid" +
        " JOIN Framework.Grupos g on g.grup_grupoid=cl.labo_departamentoid" +
        " JOIN Framework.Usuarios u on u.user_colaboradorid=c.codr_colaboradorid" +
        " WHERE ce.cexp_credencial=1 AND u.user_usuarioid= " + idUsuario.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function validaSolicitudImss(ByVal Colaboradorid As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametroas As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@colaboradorid"
        parametro.Value = Colaboradorid
        listaparametroas.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Contabilidad.SP_NFaltaIMSS_ValidaSolicitudAlta", listaparametroas)
    End Function

    Public Function consultarPatronPorNavesUsuario(ByVal usuarioId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Nomina].[SP_consultarPatronPorNavesUsuario]", listaParametros)
    End Function

    Public Function obtenerDimensionesCredencial(ByVal Naveid As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@naveid", Naveid)
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Nomina].[SP_ObtenerDimensionesCredencialPorNave]", listaParametros)
    End Function

    Public Function ObtenerNombreColaboradorCredencialEspecial(ByVal ColaboradorId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@ColaboradorID", ColaboradorId)
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Nomina].[SP_Credencial_NombreColaborador]", listaParametros)
    End Function

End Class
