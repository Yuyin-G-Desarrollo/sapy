Imports Entidades

Public Class ColaboradorNominaDA

    Public Sub guardarColaboradorNomina(ByVal col As ColaboradorNomina, ByVal idNave As Int32, ByVal idPuesto As Int32)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros = New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "colaboradorid"
        parametro.Value = col.PColaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "naveid"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "puestoid"
        parametro.Value = idPuesto
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "nss"
        parametro.Value = col.PNss
        listaParametros.Add(parametro)

        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "fechaAltaImss"
        'parametro.Value = col.PFechaAltaImss
        'listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "formaPago"
        parametro.Value = col.PFormaPago
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "usuarioCreo"
        parametro.Value = SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "infonavit"
        'parametro.Value = col.PInfonavit
        'listaParametros.Add(parametro)

        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "salariodiario"
        'parametro.Value = col.PSalarioDiario
        'listaParametros.Add(parametro)

        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "infonavitTipo"
        'parametro.Value = col.PInfonavitTipo
        'listaParametros.Add(parametro)

        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "infonavitmonto"
        'parametro.Value = col.PInfonavitMonto
        'listaParametros.Add(parametro)

        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "cono_infonavit_fecha"
        'parametro.Value = col.PfechaAltaInfonavit
        'listaParametros.Add(parametro)

        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "cono_isrmonto"
        'parametro.Value = col.PMontoISR
        'listaParametros.Add(parametro)

        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "cono_asegurado"
        'parametro.Value = col.PAsegurado
        'listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "cono_externo"
        parametro.Value = col.PExterno
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "patron"
        parametro.Value = col.PPatron.Ppatronid
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "cpsat"
        parametro.Value = col.PCPSAT
        listaParametros.Add(parametro)

        objPersistencia.EjecutarSentenciaSP("Nomina.SP_alta_colaboradorNomina", listaParametros)
    End Sub

    Public Function buscarColaboradorNomina(ByVal colaboradorId As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "select * from Nomina.ColaboradorNomina "
        consulta += " join Nomina.Patrones on cono_patronid=patr_patronid "
        consulta += " LEFT JOIN Nominpaq.Datasource C"
        consulta += " ON C.datas_sourceid= patr_DataSource"
        consulta += " where cono_colaboradorid = " + colaboradorId.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function



    Public Sub EditarrColaboradorNomina(ByVal col As ColaboradorNomina, ByVal colaboradorId As Int32)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros = New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "colaboradorid"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "salario"
        'parametro.Value = col.PSalario
        'listaParametros.Add(parametro)

        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "patron"
        'parametro.Value = col.PPatron.Ppatronid
        'listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "nss"
        parametro.Value = col.PNss
        listaParametros.Add(parametro)

        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "fechaAltaImss"
        'parametro.Value = col.PFechaAltaImss
        'listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "formaPago"
        parametro.Value = col.PFormaPago
        listaParametros.Add(parametro)



        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "usuarioModifico"
        parametro.Value = SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)




        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "infonavit"
        'parametro.Value = col.PInfonavit

        'listaParametros.Add(parametro)


        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "salariodiario"
        'parametro.Value = col.PSalarioDiario
        'listaParametros.Add(parametro)


        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "infonavitTipo"
        'parametro.Value = col.PInfonavitTipo

        'listaParametros.Add(parametro)



        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "infonavitMonto"
        'parametro.Value = col.PInfonavitMonto
        'listaParametros.Add(parametro)

        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "cono_infonavit_fecha"
        'parametro.Value = col.PfechaAltaInfonavit
        'listaParametros.Add(parametro)

        'parametro = New SqlClient.SqlParameter ' Campo ISR
        'parametro.ParameterName = "cono_isrmonto"
        'parametro.Value = col.PMontoISR
        'listaParametros.Add(parametro)

        'parametro = New SqlClient.SqlParameter
        'parametro.ParameterName = "cono_asegurado"
        'parametro.Value = col.PAsegurado
        'listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter ' externo
        parametro.ParameterName = "cono_externo"
        parametro.Value = col.PExterno
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "cpsat"
        parametro.Value = col.PCPSAT
        listaParametros.Add(parametro)

        objPersistencia.EjecutarSentenciaSP("Nomina.SP_Editar_ColaboradorNomina", listaParametros)

    End Sub

End Class
