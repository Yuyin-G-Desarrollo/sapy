Imports Persistencia
Imports System.Data.SqlClient

Public Class ProduccionDA
    Dim lsta As New DataTable

    Public Sub AltaCortador(ByVal cortador As Entidades.CortadoresPielForro)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@colaboradorid"
        parametro.Value = cortador.copf_colaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveid"
        parametro.Value = cortador.copf_naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoCortador"
        parametro.Value = cortador.copf_tipocortador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = cortador.copf_estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreo"
        parametro.Value = cortador.copf_usuariocreo
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Produccion.SP_InsertarCortadorPielForro", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub ModificaCortador(ByVal cortador As Entidades.CortadoresPielForro)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoCortador"
        parametro.Value = cortador.copf_tipocortador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = cortador.copf_estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariomodifica"
        parametro.Value = cortador.copf_usuariomodifico
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@registro"
        parametro.Value = cortador.copf_cortadorPielForro
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Produccion.SP_ModificarCortadorPielForro", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function listadoParametroColecciones() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("[Produccion].[SP_Produccion_ConsultaColecciones]")
    End Function
    Public Function listadoParametroEstatus() As DataTable
        lsta.Clear()
        lsta.Columns.Add("Parámetro")
        lsta.Columns.Add("", GetType(Boolean))
        lsta.Columns.Add("Estatus")
        lsta.Columns(1).ColumnName = " "
        'lsta.Rows.Add(New Object() {"1", False, "PROTOTIPO"})
        'lsta.Rows.Add(New Object() {"2", False, "MUESTRA"})
        'lsta.Rows.Add(New Object() {"3", False, "AUTORIZADO PARA PROGRAMACIÓN"})
        'lsta.Rows.Add(New Object() {"4", False, "AUTORIZADO PARA PRODUCCIÓN"})
        'lsta.Rows.Add(New Object() {"5", False, "DESCONTINUADO PARA PRODUCCIÓN"})
        'lsta.Rows.Add(New Object() {"5", False, "DESCONTINUADO PARA VENTA"})
        lsta.Rows.Add(New Object() {"1", False, "DESARROLLO"})
        lsta.Rows.Add(New Object() {"2", False, "AUTORIZADO DESARROLLO"})
        lsta.Rows.Add(New Object() {"3", False, "AUTORIZADO PRODUCCIÓN"})
        lsta.Rows.Add(New Object() {"4", False, "INACTIVO NAVE"})
        lsta.Rows.Add(New Object() {"5", False, "DESCONTINUADO"})
        Return lsta


        '1   PROTOTIPO
        '2   MUESTRA
        '3   AUTORIZADO PARA PROGRAMACIÓN
        '4   AUTORIZADO PARA PRODUCCIÓN
        '5   DESCONTINUADO PARA PRODUCCIÓN
        '6   DESCONTINUADO PARA VENTA

    End Function

    Public Function listadoParametroMarcas() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("[Produccion].[SP_Produccion_ConsultaMarcas]")

    End Function

    Public Function listadoParametroNaves(tipo_Nave As Integer, IdUsuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "Maquila"
        parametro.Value = tipo_Nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter

        parametro.ParameterName = "IdUsuario"
        parametro.Value = IdUsuario
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_ConsultaNavesFiltro_Usuario]", listaparametros)

    End Function

    Public Sub altaLotesAvancesEmpleadosDepto(ByVal Empleado As Entidades.LotesAvancesEmpleadosDepto)
        'Dim operaciones As New OperacionesProcedimientosPruebas
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@idEmpleado"
        parametro.Value = Empleado.idEmpleado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idConfiguracion"
        parametro.Value = Empleado.idConfiguracion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = Empleado.estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idColaboradorSay"
        parametro.Value = Empleado.idColaboradorSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioCreoId"
        parametro.Value = Empleado.usuarioCreo
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Almacen.SP_Inserta_LotesAvancesEmpleadosDepto", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    Public Sub ModificaLotesAvancesEmpleadosDepto(ByVal Empleado As Entidades.LotesAvancesEmpleadosDepto)
        'Dim operaciones As New OperacionesProcedimientosPruebas
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@id"
        parametro.Value = Empleado.id
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idConfiguracion"
        parametro.Value = Empleado.idConfiguracion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = Empleado.estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idColaboradorSay"
        parametro.Value = Empleado.idColaboradorSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioModificaId"
        parametro.Value = Empleado.usuarioModifico
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Almacen.SP_Modifica_LotesAvancesEmpleadosDepto", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    Public Function listaColaboradores(ByVal nave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select distinct rank() OVER (ORDER BY c.codr_nombre,c.codr_apellidopaterno,c.codr_apellidomaterno) as 'No',
                c.codr_nombre +' '+c.codr_apellidopaterno+' '+c.codr_apellidomaterno 'Colaborador' ,c.codr_nombrecorto 'Nombre Corto',c.codr_colaboradorid 'ID colaborador',
                d.dept_departamento 'Departamento',d.dept_iddepto 'ID departamento', p.pues_nombre 'Puesto',p.pues_puestoid 'ID puesto',cl.labo_naveid
                from Nomina.ColaboradorLaboral as cl
                left join Nomina.Colaborador as c on c.codr_colaboradorid=cl.labo_colaboradorid
                left join Materiales.departamentos as d on d.dept_iddepto=cl.labo_departamentoid
                left join Nomina.Puestos as p on p.pues_puestoid=cl.labo_puestoid
                where cl.labo_naveid=
            </cadena>
        consulta += nave.ToString + " and c.codr_activo=1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaColaboradoresSicy(ByVal nave As Integer) As DataTable
        'Dim operaciones As New Persistencia.OperacionesProcedimientosPruebas
        'Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@IdNaveSICY"
        parametro.Value = nave
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_AltaColaboradoresAvancesProduccion]", listaParametros)

        'Dim consulta As String =
        '    <cadena>
        '        select rank() OVER (ORDER BY c.codr_nombre) as 'No',
        '        c.codr_nombre +' '+ codr_apellidopaterno+' '+ codr_apellidomaterno 'Colaborador',
        '        e.IdEmpleado 'ID colaborador', 
        '        isnull (c.codr_nombrecorto,'') 'Nombre Corto',d.IdDepto'ID departamento',
        '        d.Departamento,p.IdPuesto 'ID puesto',p.Puesto, n.Nave, e.Nave AS IdNave
        '        from Nomina.Colaborador c left join nmaEmpleados e on c.codr_nombre=e.Nombre
        '        and e.ApellidoPaterno=c.codr_apellidopaterno and c.codr_apellidomaterno=e.ApellidoMaterno
        '        left join nmaDepartamentos d on e.IdDepto=d.IdDepto and d.Nave=e.Nave
        '        left join nmaPuestos p on e.IdPuesto=p.IdPuesto and p.Nave=e.Nave
        '        left join Naves n on e.Nave=n.IdNave
        '        where c.codr_activo=1 and n.IdNave=
        '    </cadena>
        'consulta += nave.ToString
        'Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaColaboradoresSAY(ByVal IdNave As Integer, ByVal Estatus As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "IdNaveSICY"
        parametro.Value = IdNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = Estatus
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_AltaColaboradoresAvancesProduccion]", listaParametros)

    End Function

    Public Function buscarIdSicy(ByVal colaborador As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
                select codr_colaboradorid 
                from Nomina.Colaborador 
                where codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno
            </cadena>
        consulta += "= '" + colaborador.ToString + "' and codr_activo =1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaDepartamentos(ByVal nave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
                  select distinct rank() OVER (ORDER BY d.Departamento) as 'No',
			 d.IdDepto 'ID departamento', d.Departamento, con.IdConfiguracion 'ID'
			 from nmaDepartamentos as d left join LotesAvancesConfigNaveDepto as con
			 on con.IdDepto=d.IdDepto
			 where StDepto='A'
            </cadena>
        consulta += "and con.IdNave=" + nave.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'Public Function listaDepartamentosAvance() As DataTable
    '    Dim operaciones As New Persistencia.OperacionesProcedimientos
    '    Dim listaParametros As New List(Of SqlParameter)
    '    Dim parametros As New SqlParameter
    '    Return operaciones.EjecutarConsultaSP("[Produccion].[SP_MostrarDepartamentosAvace]", listaParametros)
    'End Function

    Public Function ConsultaCortadores(ByVal nave As Integer, ByVal tipo As Integer, ByVal estatus As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select '' ' ',cpf.copf_cortadorpielforroid 'ID', cl.codr_colaboradorid 'ID colaborador',
            cl.codr_nombre+' '+cl.codr_apellidopaterno+' '+cl.codr_apellidomaterno 'Cortador',
            cl.codr_nombrecorto 'Nombre Corto',tc.tcor_descripcion 'Tipo Cortador',
            case WHEN CPF.copf_estatus=1 then 'ACTIVO' ELSE 'INACTIVO' END AS 'Estatus'
            from Produccion.CortadorPielForro as cpf left join Nomina.Colaborador as cl on cl.codr_colaboradorid=cpf.copf_colaboradorid
            inner join Produccion.TipoCortador tc on tc.tcor_tipocortadorid=cpf.copf_tipocortador         
        </cadena>
        consulta += " WHERE cpf.copf_naveid=" & nave & "  and cpf.copf_estatus=" & estatus & " "
        If tipo > 0 Then
            consulta += " and cpf.copf_tipocortador=" & tipo & " "
        End If
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function buscarCortadorRepetido(ByVal id As Integer, ByVal tipo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select copf_colaboradorid from Produccion.CortadorPielForro
		                    </cadena>
        consulta += " where copf_colaboradorid=" + id.ToString
        consulta += "and copf_tipocortador=" + tipo.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function idNaveSay(ByVal nave As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
              select nave_naveid from Framework.Naves where nave_nombre like
            </cadena>
        consulta += "'" + nave + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscarRegistrosRepetidosAvancesDeProduccion(ByVal empleado As Integer, ByVal idConfiguracion As Integer) As DataTable
        'Dim operaciones As New Persistencia.OperacionesProcedimientosPruebas
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
                select IdEmpleadoDepto 
                from LotesAvancesEmpleadosDepto
                --where IdEmpleado= 
                where idColaboradorSay =
            </cadena>
        consulta += empleado.ToString
        consulta += "and IdConfiguracion = "
        consulta += idConfiguracion.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listarFracciones() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_Fracciones_ListarFracciones]", listaParametros)

    End Function

    Public Function DestajosFraccionesPuesto(ByVal FracXPuesto As Entidades.FraccionesPorPuesto) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@FraccionId"
        parametro.Value = FracXPuesto.FraccionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveSayId"
        parametro.Value = FracXPuesto.NaveSayid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@AreaId"
        parametro.Value = FracXPuesto.AreaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DepartamentoId"
        parametro.Value = FracXPuesto.DepartamentoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PuestoId"
        parametro.Value = FracXPuesto.PuestoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Activo"
        parametro.Value = FracXPuesto.Activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColaboradorCreoId"
        parametro.Value = FracXPuesto.ColaboradorCreoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioCreoId"
        parametro.Value = FracXPuesto.UsuarioCreoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColaboradorModificoId"
        parametro.Value = FracXPuesto.ColaboradorModificoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioModificoId"
        parametro.Value = FracXPuesto.UsuarioModificoId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[DestajosFraccionesPorPuesto]", listaParametros)

    End Function

    Public Function DestajosFraccionesPorPuestoPorNave(ByVal NaveSayid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveSayId"
        parametro.Value = NaveSayid
        listaparametros.Add(parametro)

        'Return operaciones.EjecutarConsultaSP("[Produccion].[ConsultaDestajosFraccionesPorPuestoPorNave]", listaparametros)
        Return operaciones.EjecutarConsultaSP("[Produccion].[ConsultaDestajosFraccionesPorPuestoPorNave_Nuevo]", listaparametros)

    End Function

    Public Function DepartamentosPorNave(ByVal IdNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveId"
        parametro.Value = IdNave
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_DepartamentosporNaveSicy]", listaParametros)

    End Function

    Public Function FraccionesDeptoAvance(ByVal FracDeptoAvance As Entidades.FraccionesPorPuesto) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@IdGrupo"
        parametro.Value = FracDeptoAvance.DepartamentoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NombreGrupo"
        parametro.Value = FracDeptoAvance.Departamento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdFraccion"
        parametro.Value = FracDeptoAvance.FraccionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNaveSICY"
        parametro.Value = FracDeptoAvance.NaveSICYid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColaboradorCreoId"
        parametro.Value = FracDeptoAvance.ColaboradorCreoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioCreoId"
        parametro.Value = FracDeptoAvance.UsuarioCreoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Activo"
        parametro.Value = FracDeptoAvance.Activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioModificoId"
        parametro.Value = FracDeptoAvance.UsuarioCreoId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_Inserta_Avance_FraccionesDeptoAvance]", listaParametros)

    End Function

    Public Function Consulta_FraccionesDeptoAvanceXNave(ByVal IdNaveSICY As Integer, ByVal estatus As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@IdNaveSICY"
        parametro.Value = IdNaveSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_Consulta_Avance_FraccionesDeptoAvance]", listaParametros)

    End Function

    Public Function Ediar_FraccionesDeptoAvanceXNave(ByVal FracDeptoAvance As Entidades.FraccionesPorPuesto) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@IdTabla"
        parametro.Value = FracDeptoAvance.idTabla
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdGrupo"
        parametro.Value = FracDeptoAvance.DepartamentoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NombreGrupo"
        parametro.Value = FracDeptoAvance.Departamento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Activo"
        parametro.Value = FracDeptoAvance.Activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioModificoId"
        parametro.Value = FracDeptoAvance.UsuarioModificoId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_Editar_Avance_FraccionesDeptoAvance]", listaParametros)

    End Function

    Public Function listarFraccionesAvanceDepto(ByVal IdNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@IdNaveSICY"
        parametro.Value = IdNave
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_Fracciones_ListarFraccionesDeptoAvance]", listaParametros)

    End Function

    Public Function DestajosFraccionesPuesto_Editar(ByVal FracXPuesto As Entidades.FraccionesPorPuesto, ByVal accion As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@Identidad"
        parametro.Value = FracXPuesto.idTabla
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveSayId"
        parametro.Value = FracXPuesto.NaveSayid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FraccionId"
        parametro.Value = FracXPuesto.FraccionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@AreaId"
        parametro.Value = FracXPuesto.AreaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DepartamentoId"
        parametro.Value = FracXPuesto.DepartamentoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PuestoId"
        parametro.Value = FracXPuesto.PuestoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColaboradorModificoId"
        parametro.Value = FracXPuesto.ColaboradorModificoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioModificoId"
        parametro.Value = FracXPuesto.UsuarioModificoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@accion"
        parametro.Value = accion
        listaParametros.Add(parametro)


        Return operaciones.EjecutarConsultaSP("[Produccion].[DestajosFraccionesPorPuesto_Editar]", listaParametros)

    End Function

    Public Function listaFraccionesIncremento()
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_ListaFraccionesIncremento]", New List(Of SqlParameter))
    End Function

    Public Function GuardarIncrementofracciones(ByVal listaFracciones As String, ByVal idnave As Integer, ByVal usuario As String, ByVal porcentajeAplicado As Double)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@listaFracciones", listaFracciones)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@idnave", idnave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuario", usuario)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@porcentajeAplicado", porcentajeAplicado)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ActualizaIncrementoFracciones]", listaParametros)

    End Function

    Public Function ConsultaHistorialIncrementoFracciones(ByVal naveid As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@idNave", naveid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaIstorialIncremento]", listaParametros)
    End Function

End Class
