Imports System.Data.SqlClient
Public Class AltaClienteProveedorInternoDA
    Public Function ObtenerProveedores()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable
        dtResultadoConsulta = objPersistencia.EjecutaConsulta("[Cobranza].[SP_Consulta_Proveedores]")
        Return dtResultadoConsulta
    End Function
    Public Function ObtenerClientes()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable
        dtResultadoConsulta = objPersistencia.EjecutaConsulta("[Cobranza].[SP_Consulta_Clientes]")
        Return dtResultadoConsulta
    End Function
    Public Function obtenerNaves()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable
        dtResultadoConsulta = objPersistencia.EjecutaConsulta("[Cobranza].[SP_Consulta_Naves]")
        Return dtResultadoConsulta
    End Function
    Public Function ConsultaCuentasBancosClienteInterno(ByVal objCliente As Entidades.ConfiguracionClienteProveedorInterno)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "cliente"
        parametro.Value = objCliente.ClienteInterno
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_Consulta_CuentaBancariaInterno]", listaParametros)

        Return dtResultadoConsulta
    End Function
    Public Function InsertaClienteProveedorInterno(ByVal objInsertar As Entidades.ConfiguracionClienteProveedorInterno)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "idproveedor"
        parametro.Value = objInsertar.IdProveedorInterno
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "proveedor"
        parametro.Value = objInsertar.ProveedorInterno
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "idcliente"
        parametro.Value = objInsertar.idClienteInterno
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "cliente"
        parametro.Value = objInsertar.ClienteInterno
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "idnave"
        parametro.Value = objInsertar.IdNaveInterno
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = objInsertar.NaveInterno
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "idcuenta"
        parametro.Value = objInsertar.IdCuentaBancaria
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "idusuario"
        ' parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        parametro.Value = 1000
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_Inserta_ProveedorClienteInterno]", listaParametros)

        Return dtResultadoConsulta
    End Function
End Class
