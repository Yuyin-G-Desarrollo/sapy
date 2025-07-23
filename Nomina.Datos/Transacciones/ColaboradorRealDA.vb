Public Class ColaboradorRealDA

    Public Function BuscarDatosReales(ByVal idEmpleado As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.ColaboradorReal where real_colaboradorid=" + idEmpleado.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Sub GuardarColaboradorReal(ByVal real As Entidades.ColaboradorReal)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New List(Of SqlClient.SqlParameter)
        Dim param As New SqlClient.SqlParameter

        param.ParameterName = "colaboradorid"
        param.Value = real.PColaboradorId.PColaboradorid
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "salario"
        param.Value = real.PCantidad
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "fechaingreso"
        param.Value = real.PFecha
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "tipopago"
        param.Value = real.PTipo
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "tiposueldo"
        param.Value = real.PTipoPago
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "real_cuenta"
        param.Value = real.PNumero
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "usuario"
        param.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "banco"
        param.Value = real.PBanco
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "real_costofraccion"
        param.Value = real.PCostoFraccion
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "SueldoSemanalAguinaldo"
        param.Value = real.PSueldoSemanalAguinaldo
        parametros.Add(param)


        objPersistencia.EjecutarConsultaSP("Nomina.SP_altascolaboradorreal", parametros)
    End Sub



    Public Sub EditarColaboradorReal(ByVal real As Entidades.ColaboradorReal, ByVal colaboradorId As Int32)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New List(Of SqlClient.SqlParameter)
        Dim param As New SqlClient.SqlParameter

        param.ParameterName = "colaboradorid"
        param.Value = real.PColaboradorId.PColaboradorid
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "@salario"
        param.Value = real.PCantidad
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "fechaingreso"
        param.Value = real.PFecha
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "tipopago"
        param.Value = real.PTipo
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "tiposueldo"
        param.Value = real.PTipoPago
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "real_cuenta"
        param.Value = real.PNumero
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "usuario"
        param.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "banco"
        param.Value = real.PBanco
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "real_costofraccion"
        param.Value = real.PCostoFraccion
        parametros.Add(param)

        param = New SqlClient.SqlParameter
        param.ParameterName = "SueldoSemanalAguinaldo"
        param.Value = real.PSueldoSemanalAguinaldo
        parametros.Add(param)

        objPersistencia.EjecutarConsultaSP("Nomina.SP_Editar_Colaborador_Real", parametros)
    End Sub


    Public Sub insertarFaltaColaboradorNuevo(ByVal idNave As Int32, ByVal fecha As String, ByVal idColaborador As Int32, ByVal tipoCheck As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "INSERT INTO ControlAsistencia.RegistroCheck(regcheck_naveid, regcheck_automatico, regcheck_colaborador, regcheck_resultado, regcheck_tipo_check)" +
                    "VALUES(" + idNave.ToString + ",'" + fecha + "', " + idColaborador.ToString + " ,0 , " + tipoCheck.ToString + ")"
        operacion.EjecutaSentencia(cadena)


    End Sub


End Class
