Imports Persistencia
Imports System.Data.SqlClient

Public Class CuentasBancariasDA

    Public Function Consulta_lista_Cuentas_Bancarias(razonSocialID As Integer, bancoID As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter


        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@razonSocialID"
        parametro.Value = razonSocialID
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@bancoID"
        parametro.Value = bancoID
        ListaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_CuentasBancarias_Consulta_lista_Cuentas_Bancarias]", ListaParametros)

        'Dim consulta As String = String.Empty
        'consulta += " " +
        '            " SELECT" +
        '            " cuba_cuentaid AS 'ID'," +
        '            " cuba_numero AS 'Numero de Cuenta'," +
        '            " cuba_clabeinterbancaria," +
        '            " cuba_cuentahabiente AS 'Cuentahabiente'," +
        '            " cuba_empresaid AS 'Empresa ID'," +
        '            " essc_razonsocial AS 'Razón Social'," +
        '            " cuba_cuentasicyid AS 'Cuenta SICY ID'," +
        '            " CAST(CB.Cuenta + ' - ' + CB.Nombre AS VARCHAR(MAX)) AS 'Numero de Cuenta SICY'," +
        '            " cuba_bancoid AS 'Banco ID'," +
        '            " banc_nombre AS 'Banco', " +
        '            " cuba_cuentacontpaqid as 'Id Cuenta Contpaq', " +
        '            " cuba_bancocontpaqid as 'Id Banco Contpaq', " +
        '            " cuba_monedaid, m.mone_nombre" +
        '            " FROM Bancos.CuentasBancarias" +
        '            " LEFT JOIN Framework.empresaSaySicyContpaq ON essc_empresaid = cuba_empresaid" +
        '            " LEFT JOIN [192.168.2.2].[Yuyin_Respaldo].[dbo].[CuentasBancarias] AS CB ON CB.IdCuenta = cuba_cuentasicyid" +
        '            " LEFT JOIN Framework.Bancos ON banc_bancoid = cuba_bancoid" +
        '            " JOIN Framework.Moneda m ON m.mone_monedaid = cuba_monedaid" +
        '            " WHERE cuba_status = 1"
        'If razonSocialID > 0 Then
        '    consulta += " AND cuba_empresaid = " + razonSocialID.ToString
        'End If
        'If bancoID > 0 Then
        '    consulta += " AND banc_bancoid = " + bancoID.ToString
        'End If
        'consulta += " ORDER BY essc_razonsocial"

        'Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function alta_edicion_CuentaBancaria(cuentaid As Integer, numero As String, cuentahabiente As String, empresaid As Integer _
                                                   , cuentasicyid As Integer, bancoid As Integer, cuentacontpaqid As Integer,
                                                   bancocontpaqid As Integer, status As Boolean, ByVal idMoneda As Int32, ByVal clabe As String,
                                                    incluircotizaciones As Boolean, pagoremision As Boolean, pagofacturas As Boolean)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @cuentaid AS INT
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@cuentaid"
        parametro.Value = cuentaid
        listaParametros.Add(parametro)

        ',@numero AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "@numero"
        parametro.Value = numero
        listaParametros.Add(parametro)

        ',@cuentahabiente AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "@cuentahabiente"
        parametro.Value = cuentahabiente
        listaParametros.Add(parametro)

        ',@empresaid AS INT
        parametro = New SqlParameter
        parametro.ParameterName = "@empresaid"
        parametro.Value = empresaid
        listaParametros.Add(parametro)

        ',@cuentasicyid AS INT
        parametro = New SqlParameter
        parametro.ParameterName = "@cuentasicyid"
        parametro.Value = cuentasicyid
        listaParametros.Add(parametro)

        ',@bancoid AS INT
        parametro = New SqlParameter
        parametro.ParameterName = "@bancoid"
        parametro.Value = bancoid
        listaParametros.Add(parametro)

        ',@cuentacontpaqid AS INT
        parametro = New SqlParameter
        parametro.ParameterName = "@cuentacontpaqid"
        parametro.Value = cuentacontpaqid
        listaParametros.Add(parametro)

        ',@bancocontpaqid AS INT
        parametro = New SqlParameter
        parametro.ParameterName = "@bancocontpaqid"
        parametro.Value = bancocontpaqid
        listaParametros.Add(parametro)

        ',@usuario AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        ',@status AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "@status"
        parametro.Value = status
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idMoneda"
        parametro.Value = idMoneda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clabe"
        parametro.Value = clabe
        listaParametros.Add(parametro)

        ',@incluircotizaciones  AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "@incluircotizaciones"
        parametro.Value = incluircotizaciones
        listaParametros.Add(parametro)

        ',@pagoremision  AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "@pagoremision"
        parametro.Value = pagoremision
        listaParametros.Add(parametro)

        ',@pagofacturas  AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "@pagofacturas"
        parametro.Value = pagofacturas
        listaParametros.Add(parametro)


        Return operaciones.EjecutarSentenciaSP("Bancos.SP_Editar_CuentasBancarias_2", listaParametros)

    End Function

    Public Function Datos_CuentaBancaria(cuentaID As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " " +
                    " SELECT * FROM Bancos.CuentasBancarias WHERE cuba_cuentaid = " + cuentaID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_Banco_Contpaq(empresaID As Integer, bancocontpaqID As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " " +
                                                       " DECLARE @servidor AS VARCHAR(MAX) SET @servidor = LTRIM(RTRIM(CAST(((SELECT essc_servidor FROM Framework.empresaSaySicyContpaq WHERE essc_empresaid = " + empresaID.ToString + ")) AS VARCHAR(MAX))))" +
                                                       " DECLARE @base_datos AS VARCHAR(MAX) SET @base_datos = LTRIM(RTRIM(CAST(((SELECT essc_empresacontpaq FROM Framework.empresaSaySicyContpaq WHERE essc_empresaid = " + empresaID.ToString + ")) AS VARCHAR(MAX))))" +
                                                       " " +
                                                       " DECLARE @query AS VARCHAR(MAX)" +
                                                       " 	SET @query ='				" +
                                                       " 					SELECT " +
                                                       " 							Id," +
                                                       " 							Nombre" +
                                                       " 					FROM [' + @servidor + '].[' + @base_datos + '].[dbo].[Bancos]" +
                                                       "                    WHERE iD = " + bancocontpaqID.ToString +
                                                       " 					ORDER BY Nombre '" +
                                                       " " +
                                                       " EXEC (@query)"
        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
